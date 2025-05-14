using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour{
    public GameObject WinScreen;

    private bool win;

    public static UIManager uiManager;

    public TextMeshProUGUI timeCounterGameplay;
    public TextMeshProUGUI timeCounterWin;
    public TextMeshProUGUI timeCounterPause;
    private float seconds;
    private int minutes;

    public Button retryButton;
    public Button mainButton;
    public Button mainButtonPause;
    public Button returnButton;

    public GameObject pauseScreen;

    public static bool pause;

    void Awake(){
        uiManager = this;

        pause = false;
        win = false;

        retryButton.onClick.AddListener(() =>{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        returnButton.onClick.AddListener(() => {
            pause = false;
            pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            timeCounterGameplay.gameObject.SetActive(true);
        });

        mainButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });

        mainButtonPause.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });

    }

    public void showWinScreen(){
        WinScreen.SetActive(true);
        timeCounterWin.text = "Tiempo: " + minutes + ":" + Mathf.Ceil(seconds);
        timeCounterGameplay.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        win = true;
    }

    public void showPauseScreen(){
        pauseScreen.SetActive(true);
        timeCounterPause.text = "Tiempo: " + minutes + ":" + Mathf.Ceil(seconds);
        timeCounterGameplay.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pause = true;
    }

    void Update(){

        if(!win && !pause){
            seconds += Time.deltaTime;

            if (seconds >= 59)
            {
                minutes++;
                seconds = 0;
            }

            timeCounterGameplay.text = "Tiempo: " + minutes + ":" + Mathf.Ceil(seconds);
        }
    }
}
