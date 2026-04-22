using System.Collections;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    private DialogQueue queue;
    public bool displayingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        queue = new DialogQueue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogRequest(string text)
    {
        queue.RecordDialog(text);

        if(!displayingText)
        {
            StartCoroutine(DialogDisplay());
        }
    }

    IEnumerator DialogDisplay()
    {
        dialogText.text = queue.GetDialog();
        dialogBox.GetComponent<Animation>().Play("DialogOn");
        displayingText = true;
        GameManager.instance.timerGo = false;

        yield return new WaitForSecondsRealtime(4);

        if (queue.TextQueued())
        {
            StartCoroutine(DialogDisplay());
        }
        else
        {
            dialogBox.GetComponent<Animation>().Play("DialogOff");
            displayingText = false;
            GameManager.instance.timerGo = true;
            
        }

    }
}
