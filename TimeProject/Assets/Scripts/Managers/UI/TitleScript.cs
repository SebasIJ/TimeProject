using System.Collections;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    private bool initialDialogue = false;
    public GameObject HUD;
    public GameObject titleBox;
    public Animation titlePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (initialDialogue)
        {
            if (!UIManager.Instance.dialog.displayingText)
            {
                PlayerScript.instance.canMove = true;
                GameManager.instance.timerGo = true;
                HUD.SetActive(true);
                titleBox.SetActive(false);
                this.GetComponent<TitleScript>().enabled = false;
            }
        }
    }

    public void EndGame()
    {
        UIManager.Instance.transition.QuitGame();
    }

    public void GameStart()
    {
        if (!GameManager.instance.gameStart)
        {
            StartCoroutine(SetGame());
        }
        
    }

    IEnumerator SetGame()
    {
        GameManager.instance.gameStart = true;
        CameraManager.instance.getRequest = true;
        CameraManager.instance.requestType = 3;
        titlePanel.Play();

        yield return new WaitForSeconds(1);

        UIManager.Instance.dialog.DialogRequest("Time bomb detected...\nDefusing odds...\nUnlikely");
        UIManager.Instance.dialog.DialogRequest("Objective:\nInstall TIME_REWIND.exe\nRewind time\nDefuse Bomb");
        UIManager.Instance.dialog.DialogRequest("TIME_Rewind.exe location:\nRed Box behind you");
        UIManager.Instance.dialog.DialogRequest("Use your Z key to\ninteract with the area\n Good luck t41m unit");
        initialDialogue = true;
    }
}
