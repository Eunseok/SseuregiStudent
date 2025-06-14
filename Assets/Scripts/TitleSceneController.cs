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

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene("Stage_Select");
        }
    }
    
    private void AnimateLoop()
    {
        pressText.DOFade(0f, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
