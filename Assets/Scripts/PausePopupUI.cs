using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePopupUI : MonoBehaviour {
    
    public void OnPause() {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void OnResume() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OnRestart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExit() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Stage_Select");
    }
}