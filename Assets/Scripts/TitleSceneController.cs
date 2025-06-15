using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour {
    [SerializeField] TMP_Text pressText;
    [SerializeField] float duration = 0.8f;

    void Start() {
        AnimateLoop();
    }

    bool isLoading = false;

    void Update()
    {
        if (isLoading) return;

        if (Input.GetMouseButtonDown(0))
        {
            isLoading = true;
            StartCoroutine(DelayedSceneLoad());
        }
    }

    IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(0.1f); // 입력 무시 시간 확보
        SceneManager.LoadScene("Stage_Select");
    }

    
    void AnimateLoop()
    {
        pressText.DOFade(0f, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
