using UnityEngine;

public class FirstVisit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!GameManager.instance.level0Clear)
        {
            PlayerScript.instance.canMove = false;
            GameManager.instance.timerGo = false;
            UIManager.Instance.dialog.DialogRequest("...");
            UIManager.Instance.dialog.DialogRequest("TIME_REWIND.exe\nmalfunction detected\nSpace and time wrongly warped\nTime bomb still active");
            UIManager.Instance.dialog.DialogRequest("Analizing malfunction...\nGreat Scott...\nThe location was warped into\nA different time era");
            UIManager.Instance.dialog.DialogRequest("Specific Period data must be\nanalyzed to ignore time\nperiod during warping");
            UIManager.Instance.dialog.DialogRequest("New Objective\nFind Object specific\nto time period!\nand watch your battery");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!UIManager.Instance.dialog.displayingText)
        {
            PlayerScript.instance.canMove = true;
            GameManager.instance.timerGo = true;
            GameManager.instance.level0Clear = true;
            Destroy(gameObject);
        }
    }
}
