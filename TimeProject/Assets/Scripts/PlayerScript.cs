using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //The player is a singleton
    public static PlayerScript instance;

    public bool canMove = true;
    public bool holding = false;
    private bool switchReady = false;
    private bool stunned = false;

    public float speed;


    public Rigidbody playerRb;

    public SpriteRenderer playerSprite;
    public SpriteRenderer objectSign;

    private GameObject currSwitch;
    private GameObject currObj;

    public Transform holdPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        canMove = false;

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            playerSprite.GetComponent<Animator>().SetBool("Exec", false);
            playerSprite.GetComponent<Animator>().SetBool("Stun", false);

            PlayerMove();

            InteractKey();
        }
        else if(!stunned)
        {
            playerSprite.GetComponent<Animator>().SetBool("Exec", true);
        }
    }

    void PlayerMove()
    {
        Vector3 inputV = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if(inputV == Vector3.zero)
        {
            playerSprite.GetComponent<Animator>().SetBool("Moving", false);
        }
        else
        {
            playerSprite.GetComponent<Animator>().SetBool("Moving", true);

            if(inputV.x < 0)
            {
                playerSprite.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                playerSprite.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        playerRb.linearVelocity = new Vector3(inputV.x, playerRb.linearVelocity.y, inputV.z).normalized * speed;
    }

    void InteractKey()
    {
        if (Input.GetKeyDown(KeyCode.Z) && switchReady)
        {
            currSwitch.GetComponent<AreaSwitch>().switching = true;
            CameraManager.instance.getRequest = true;
            CameraManager.instance.completeRequest = false;
            CameraManager.instance.requestType = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && currObj != null && !holding)
        {
            currObj.GetComponent<BaseObject>().Interact();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && holding)
        {
            GetComponentInChildren<BaseObject>().Interact();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (canMove && (other.gameObject.tag == "AreaSwitch" || other.gameObject.GetComponent<BaseObject>() != null))
        {
            objectSign.color = new Color(1f, 1f, 1f, 1f);
        }
        
        
        if(other.gameObject.tag == "AreaSwitch")
        {
            currSwitch = other.gameObject;
            switchReady = true;                
        }
        else if(other.gameObject.GetComponent<BaseObject>() != null)
        {
            currObj = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        objectSign.color = new Color(1f, 1f, 1f, 0f);
        currSwitch = null;
        currObj = null;
        switchReady = false;
    }

    public void DestroyingObject()
    {
        objectSign.color = new Color(1f, 1f, 1f, 0f);
        currSwitch = null;
        currObj = null;
        switchReady = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Fireball>(out Fireball fire))
        {
            playerSprite.GetComponent<Animator>().SetBool("Stun", true);
            StartCoroutine(StunTime());
        }
    }

    private IEnumerator StunTime()
    {
        stunned = true;
        canMove = false;
        GetComponent<CapsuleCollider>().enabled = false;
        playerRb.linearVelocity = Vector3.zero;

        yield return new WaitForSeconds(5);

        stunned = false;
        canMove = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
