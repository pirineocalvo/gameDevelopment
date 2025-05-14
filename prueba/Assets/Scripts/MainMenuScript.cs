using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });

        exitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }
}
