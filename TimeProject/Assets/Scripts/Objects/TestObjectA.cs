using UnityEngine;

public class TestObjectA : BaseObject
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectHolder = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract)
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
            
        }
    }

    public override void Interact()
    {
        base.Interact();

        if(!canHold)
        {
            GetComponent<WayPointMover>().move = true;
        }
    }
}
