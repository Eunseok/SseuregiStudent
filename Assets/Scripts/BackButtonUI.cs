using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtonUI : MonoBehaviour {
    Button button;
    
    void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnBackButtonClicked);
    }

    void OnBackButtonClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}