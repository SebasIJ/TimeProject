using System.Collections;
using UnityEngine;

public class ExecutionMode : MonoBehaviour
{
    public Sprite upArrow, downArrow, leftArrow, rightArrow;

    public GameObject execMenu, rewind, hint, slow;  

    public UnityEngine.UI.Image input1, input2, input3, input4;

    public bool execEnabled = false;
    public bool readingInputs = false;
    public bool allInputs = false;

    KeyCode pressed;
    ExecutionCheck check;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input1.color = new Color(0, 0, 0, 0);
        input2.color = new Color(0, 0, 0, 0);
        input3.color = new Color(0, 0, 0, 0);
        input4.color = new Color(0, 0, 0, 0);

        execMenu.SetActive(false);
        check = new ExecutionCheck();

        check.upArrow = upArrow;
        check.downArrow = downArrow;
        check.leftArrow = leftArrow;
        check.rightArrow = rightArrow;
        check.exMode = this;
    }

    private void OnGUI()
    {
        Event e = Event.current;

        if(e.isKey && e.type == EventType.KeyDown)
        {
            pressed = e.keyCode;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            if(PlayerScript.instance.canMove && !execEnabled && !UIManager.Instance.dialog.displayingText)
            {

                OpenMenu();

            }
            else if(!PlayerScript.instance.canMove && execEnabled)
            {

                CloseMenu();

            }

        }

        


        if (execEnabled)
        {
            if ( pressed == KeyCode.DownArrow || pressed == KeyCode.UpArrow || pressed == KeyCode.LeftArrow || pressed == KeyCode.RightArrow)
            {

                if (input1.color.a == 0)
                {
                    check.ReadInput(input1, pressed);
                    StartCoroutine(InputTime());
                }
                else if (input2.color.a == 0 && readingInputs)
                {
                    check.ReadInput(input2, pressed);
                }
                else if (input3.color.a == 0 && readingInputs)
                {
                    check.ReadInput(input3, pressed);
                }
                else if (input4.color.a == 0 && readingInputs)
                {
                    check.ReadInput(input4, pressed);
                    allInputs = true;
                }

                pressed = KeyCode.None;
            }
        }
    }

    void OpenMenu()
    {
        PlayerScript.instance.canMove = false;
        PlayerScript.instance.playerRb.linearVelocity = Vector3.zero;
        GameManager.instance.timerGo = false;

        execMenu.SetActive(true);

        execEnabled = true;

        if (GameManager.instance.rewindDisk) { rewind.SetActive(true); }
        else { rewind.SetActive(false); }

        if (GameManager.instance.hintDisk) { hint.SetActive(true); }
        else { hint.SetActive(false); }

        if (GameManager.instance.slowDisk) { slow.SetActive(true); }
        else { slow.SetActive(false); }

        execMenu.GetComponent<Animation>().Play("AnimOpen");

        CameraManager.instance.getRequest = true;
        CameraManager.instance.requestType = 2;
    }

    public void CloseMenu()
    {

        execMenu.GetComponent<Animation>().Play("AnimClose");
        PlayerScript.instance.canMove = true;
        GameManager.instance.timerGo = true;
        execEnabled = false;
        allInputs = false;

        CameraManager.instance.getRequest = true;
        CameraManager.instance.requestType = 3;

    }

    

    IEnumerator InputTime()
    {
        readingInputs = true;

        yield return new WaitForSeconds(3);

        if (allInputs)
        {
            check.CheckInputs(input1, input2, input3, input4);
        }

        input1.color = new Color(0, 0, 0, 0);
        input2.color = new Color(0, 0, 0, 0);
        input3.color = new Color(0, 0, 0, 0);
        input4.color = new Color(0, 0, 0, 0);
        readingInputs = false;
        allInputs = false;
    }
}
