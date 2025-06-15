using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static readonly int Throw = Animator.StringToHash("Throw");

    [Header("Stage")]
    public int totalQuestions;
    public int requiredBossHits = 3;
    public float questionInterval = 1f;
    
    int currentStage;
    int correctCount = 0;
    int wrongCount = 0;
    
    bool isGameOver = false;
    public bool IsGameOver => isGameOver;
    
    [Header("UI")]
    public Transform uiRoot;
    public TMP_Text questionText;
    public Slider progressBar;
    public Button[] answerButtons;
    public ResultPopupUI resultPopup;

    [Header("Spawn & Projectile")]
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    public GameObject projectilePrefab;
    
    [Header("Player")]
    public Transform playerTransform;
    public Transform projectileSpawnPoint;
    [SerializeField] Animator playerAnimator;
    
    private GameObject pendingProjectile;
    private GameObject currentEnemy;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        currentStage = PlayerPrefs.GetInt("SelectedStage", 1);
        totalQuestions = GetQuestionCountForStage(currentStage);
        progressBar.maxValue = totalQuestions;
        progressBar.value = 0;
        SpawnNextEnemy();
    }

    int GetQuestionCountForStage(int stage)
    {
        if (stage == 1) return 5;
        if (stage == 2 || stage == 3) return 7;
        if (stage == 4) return 7 + requiredBossHits;
        return 5;
    }

    void SpawnNextEnemy()
    {
        if (isGameOver) return;

        currentEnemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
        currentEnemy.GetComponent<EnemyController>().Init(playerTransform);
        
        GenerateQuestion();
    }

    void GenerateQuestion()
    {
        int a = Random.Range(2, 10);
        int b = Random.Range(2, 10);
        int answer = a * b;

        questionText.text = $"{a} × {b} = ?"; // 곱셈 기호

        List<int> options = new List<int> { answer };

        while (options.Count < 4)
        {
            int rand = Random.Range(answer - 10, answer + 10);
            if (!options.Contains(rand) && rand >= 0) options.Add(rand);
        }

        options = options.OrderBy(_ => Random.value).ToList();

        for (int i = 0; i < 4; i++)
        {
            int val = options[i];
            var btn = answerButtons[i];
            btn.GetComponentInChildren<TMP_Text>().text = val.ToString();
            btn.onClick.RemoveAllListeners();

            btn.onClick.AddListener(() =>
            {
                OnAnswerSelected(val == answer, btn);
            });
        }

        SetAnswerButtonsInteractable(true);
        SetButtonColors();
    }

    void SetAnswerButtonsInteractable(bool interactable)
    {
        foreach (var btn in answerButtons)
            btn.interactable = interactable;
    }

    void OnAnswerSelected(bool correct, Button clickedButton)
    {
        if (isGameOver) return;

        SetAnswerButtonsInteractable(false);

        if (correct)
        {
            SetButtonColors(correctBtn: clickedButton);
            playerAnimator.SetTrigger(Throw);
            pendingProjectile = Instantiate(projectilePrefab, projectileSpawnPoint);
        }
        else
        {
            wrongCount++;
            SetButtonColors(wrongBtn: clickedButton);
            Invoke(nameof(GenerateQuestion), questionInterval);
        }
    }


    public void FirePendingProjectile()
    {
        if (pendingProjectile == null || currentEnemy == null) return;

        pendingProjectile.transform.parent = null;
        pendingProjectile.GetComponent<Projectile>().Fire(currentEnemy.transform);
        pendingProjectile = null;
    }
    
    void SetButtonColors(Button correctBtn = null, Button wrongBtn = null)
    {
        foreach (var btn in answerButtons)
        {
            var colors = btn.colors;

            if (btn == correctBtn)
                colors.disabledColor = Color.green;
            else if (btn == wrongBtn)
                colors.disabledColor = Color.red;
            else
                colors.disabledColor = Color.gray;

            btn.colors = colors;
        }
    }
    

    public void OnEnemyKilled()
    {
        correctCount++;
        progressBar.value = correctCount;

        Invoke(correctCount >= totalQuestions ? nameof(CompleteStage) : nameof(SpawnNextEnemy), questionInterval);
    }

    void CompleteStage()
    {
        if (isGameOver) return;
        isGameOver = true;

        int star = 3 - wrongCount;
        if (star < 0) star = 0;

        // 저장
        PlayerPrefs.SetInt($"Stage_{currentStage}_Stars", Mathf.Max(PlayerPrefs.GetInt($"Stage_{currentStage}_Stars", 0), star));
        if (PlayerPrefs.GetInt("CurrentStageProgress", 1) == currentStage && currentStage < 4)
            PlayerPrefs.SetInt("CurrentStageProgress", currentStage + 1);

        PlayerPrefs.SetInt("ResultStar", star);
        PlayerPrefs.SetInt("GameSuccess", 1);
        
        ShowResultPopup(star, true);
    }

    public void FailGame()
    {
        if (isGameOver) return;
        isGameOver = true;
        
        PlayerPrefs.SetInt("ResultStar", 0);
        PlayerPrefs.SetInt("GameSuccess", 0);
        
        ShowResultPopup(0, false);
    }

    void ShowResultPopup(int starCount, bool success) {
        var resultPopupInstance = Instantiate(resultPopup ,uiRoot);
        resultPopupInstance.ShowResult(starCount, success);
    }
}
