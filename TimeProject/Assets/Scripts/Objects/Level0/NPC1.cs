using UnityEngine;

public class NPC1 : BaseObject
{
    bool firstInteract = false;
    bool touchingCorrect = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract && !firstInteract)
        {
            GetComponent<WayPointMover>().move = true;
            UIManager.Instance.dialog.DialogRequest("Input password to get key info");
            plyInteract = false;
            firstInteract = true;
        }
        else if (plyInteract && !touchingCorrect)
        {
            UIManager.Instance.dialog.DialogRequest("Incorrect password");
            plyInteract = false;
        }
        else if (plyInteract && touchingCorrect)
        {
            UIManager.Instance.dialog.DialogRequest("Press Secret button\nUnder grasss patch\nTool required");
            plyInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "NPC1CorrectPos")
        {
            touchingCorrect = true;
            Debug.Log("EnterGreen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "NPC1CorrectPos")
        {
            touchingCorrect = false;
        }
    }
}
