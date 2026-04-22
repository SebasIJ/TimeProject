using UnityEngine;

public class BaseObject : MonoBehaviour
{
    //Every object should inherit from this class
    //Held objects will work fine from just ticking the canHold boolean, further logic is optional
    //Use TestObjectA or BaseObject if all you want is a held object whose functionality is tied to another object just checking its name or tag
    //Other objects must have their logic added individually
    protected bool plyInteract;
    protected bool objInteract;
    private bool held;
    public bool canHold;

    public GameObject ObjectHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted " + this.name);
        if (canHold && !PlayerScript.instance.holding)
        {
            transform.position = PlayerScript.instance.holdPoint.position;
            transform.SetParent(PlayerScript.instance.transform);
            PlayerScript.instance.holding = true;
            PlayerScript.instance.objectSign.color = new Color(1f, 1f, 1f, 0f);
            held = true;
            GetComponent<SphereCollider>().enabled = false;
        }
        else if(canHold && held)
        {
            transform.SetParent(ObjectHolder.transform);
            transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
            PlayerScript.instance.holding = false;
            held = false;
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            plyInteract = true;
        }
    }
}
