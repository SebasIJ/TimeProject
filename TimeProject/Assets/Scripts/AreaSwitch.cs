using UnityEngine;

public class AreaSwitch : MonoBehaviour
{
    public bool switching = false;
    //private bool levelReady = false;

    public GameObject level;

    private int rotateCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.gameStart)
        {
            if (switching)
            {
                Switching();
            }
        }
    }

    void Switching()
    {
        PlayerScript.instance.playerSprite.color = new Color(1f, 1f, 1f, 0f);
        PlayerScript.instance.objectSign.color = new Color(1f, 1f, 1f, 0f);
        PlayerScript.instance.canMove = false;

        foreach(Transform child in PlayerScript.instance.transform)
        {
            child.gameObject.SetActive(false);
        }

        if(rotateCount < 45)
        {
            rotateCount++;
            if (transform.position.x > 0)
            {
                level.transform.Rotate(0, 2, 0);
            }
            else
            {
                level.transform.Rotate(0, -2, 0);
            }

            if(rotateCount == 30)
            {
                CameraManager.instance.getRequest = true;
                CameraManager.instance.completeRequest = false;
                CameraManager.instance.requestType = 3;
            }
        }
        else if(CameraManager.instance.completeRequest)
        {
            PlayerScript.instance.playerSprite.color = new Color(1f, 1f, 1f, 1f);
            PlayerScript.instance.gameObject.transform.position = new Vector3(transform.position.x *-1, transform.position.y, transform.position.z);
            PlayerScript.instance.canMove = true;
            switching = false;
            rotateCount = 0;

            foreach (Transform child in PlayerScript.instance.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        
        
    }
}
