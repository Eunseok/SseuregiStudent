using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPopupUI : MonoBehaviour {
    public GameObject star1, star2, star3;
    public GameObject clearRoot, failRoot;

    public void ShowResult(int starCount, bool success) {
      
        star1.SetActive(starCount >= 1);
        star2.SetActive(starCount >= 2);
        star3.SetActive(starCount == 3);
        clearRoot.SetActive(success);

        failRoot.SetActive(!success);
    }

    public void OnRetry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExit() {
        SceneManager.LoadScene("Stage_Select");
    }
}