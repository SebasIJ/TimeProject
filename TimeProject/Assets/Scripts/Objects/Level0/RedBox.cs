using UnityEngine;

public class RedBox : BaseObject
{
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract && !GameManager.instance.level0Key)
        {
            UIManager.Instance.dialog.DialogRequest("Box locked for\nSecurity reasons");
            UIManager.Instance.dialog.DialogRequest("Ask Z0 unit on duty\nFor the key");
            plyInteract = false;
        }
        else if (plyInteract && GameManager.instance.level0Key)
        {
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - speed * Time.deltaTime,transform.localScale.y - speed * Time.deltaTime, transform.localScale.z - speed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
                PlayerScript.instance.DestroyingObject();
            }
        }
    }
}
