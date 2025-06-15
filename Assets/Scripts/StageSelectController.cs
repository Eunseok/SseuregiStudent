using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour
{
    [SerializeField] GameObject stageButtonParent;
    StageButtonUI[] stageButtons;

    void Start()
    {
        stageButtons = stageButtonParent.GetComponentsInChildren<StageButtonUI>();
        
        int progress = PlayerPrefs.GetInt("CurrentStageProgress", 1);

        for (int i = 0; i < stageButtons.Length; i++)
        {
            int stageNum = i + 1;
            int starCount = PlayerPrefs.GetInt($"Stage_{stageNum}_Stars", 0);

            bool isUnlocked = stageNum <= progress;

            stageButtons[i].Setup(stageNum, starCount, isUnlocked, 
                stageNum == progress && starCount == 0);
        }
    }
    
    public void SelectStage(int stage)
    {
        PlayerPrefs.SetInt("SelectedStage", stage);
        SceneManager.LoadScene("Gameplay");
    }
}