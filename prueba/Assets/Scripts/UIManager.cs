using UnityEngine;

public class UIManager : MonoBehaviour{
    public GameObject WinScreen;

    public static UIManager uiManager;

    void Awake(){
        uiManager = this;
    }

    public void showWinScreen(){
        WinScreen.SetActive(true);
    }
}
