using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExecutionCheck
{
    public Sprite upArrow, downArrow, leftArrow, rightArrow;
    public ExecutionMode exMode;

    public void ReadInput(UnityEngine.UI.Image inputImage, KeyCode keyPressed)
    {

        switch(keyPressed)
        {
            case KeyCode.UpArrow:

                inputImage.sprite = upArrow;
                inputImage.color = Color.white;
                break;

            case KeyCode.DownArrow:

                inputImage.sprite = downArrow;
                inputImage.color = Color.white;
                break;

            case KeyCode.LeftArrow:

                inputImage.sprite = leftArrow;
                inputImage.color = Color.white;
                break;

            case KeyCode.RightArrow:

                inputImage.sprite = rightArrow;
                inputImage.color = Color.white;
                break;
        }

    }

    public void CheckInputs(UnityEngine.UI.Image input1, UnityEngine.UI.Image input2, UnityEngine.UI.Image input3, UnityEngine.UI.Image input4)
    {
        //ShutDown
        if(input1.sprite == downArrow && input2.sprite == downArrow && input3.sprite == downArrow && input4.sprite == downArrow)
        {
            UIManager.Instance.transition.QuitGame();
            exMode.CloseMenu();
            Debug.Log("ShutDown");
        }
        //Slow
        else if (input1.sprite == leftArrow && input2.sprite == leftArrow && input3.sprite == downArrow && input4.sprite == downArrow && GameManager.instance.slowDisk)
        {
            if(GameManager.instance.battery > 0)
            {
                SlowTime();
                exMode.CloseMenu();
                Debug.Log("Slow");                
            }
            else
            {
                UIManager.Instance.dialog.DialogRequest("Out of battery");
            }
        }
        //Hint
        else if (input1.sprite == rightArrow && input2.sprite == upArrow && input3.sprite == leftArrow && input4.sprite == downArrow && GameManager.instance.hintDisk)
        {
            if (GameManager.instance.battery > 0)
            {
                LevelHint();
                exMode.CloseMenu();
                Debug.Log("Hint");
            }
            else
            {
                UIManager.Instance.dialog.DialogRequest("Out of battery");
            }           
        }
        //Rewind
        else if (input1.sprite == upArrow && input2.sprite == leftArrow && input3.sprite == upArrow && input4.sprite == leftArrow && GameManager.instance.rewindDisk)
        {
            if( GameManager.instance.battery > 0)
            {
                RewindTime();
                exMode.CloseMenu();
            }
            else
            {
                UIManager.Instance.dialog.DialogRequest("Out of battery");
            }            
        }
    }

    void SlowTime()
    {
        if (GameManager.instance.secondLenght == 1)
        {
            UIManager.Instance.dialog.DialogRequest("Time Has been slowed");
            GameManager.instance.secondLenght = 2;
            GameManager.instance.battery--;
        }
        else
        {
            UIManager.Instance.dialog.DialogRequest("Time is already slow");
        }
    }

    void RewindTime()
    {
        RewindTime rewindTime = new RewindTime();

        rewindTime.Rewind();

        if (GameManager.instance.level0Clear)
        {            
            GameManager.instance.battery--;
        }       
    }

    void LevelHint()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                UIManager.Instance.dialog.DialogRequest("Analyzing Area...");
                UIManager.Instance.dialog.DialogRequest("Era Object located in River\nT41M Unit not water resistant");
                UIManager.Instance.dialog.DialogRequest("Volcano sensitivity is high, any disturbance could trigger an eruption");
                break;
            case 2:
                UIManager.Instance.dialog.DialogRequest("Level 2 hint");
                break;
            case 3:
                UIManager.Instance.dialog.DialogRequest("Level 3 hint");
                break;
            case 4:
                UIManager.Instance.dialog.DialogRequest("Final Level hint");
                break;
            default:
                UIManager.Instance.dialog.DialogRequest("This Level should have no hint");
                break;
        }

        GameManager.instance.battery--;
    }    
}
