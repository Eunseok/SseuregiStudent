using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonUI : MonoBehaviour {
    public Image stageImage;
    public TMP_Text stageText;

    public Button button;

    public GameObject[] stars; // 3개
    public GameObject focusHighlight;

    public void Setup(int stage, int starCount, bool unlocked, bool isFocus) {
        button.interactable = unlocked;
        
        stageImage.color = unlocked ? Color.white : Color.gray;
        stageText.color = unlocked ? Color.white : Color.gray;

        focusHighlight.SetActive(isFocus);

        for (int i = 0; i < stars.Length; i++)
            stars[i].SetActive(i < starCount);
    }
}