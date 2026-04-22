using UnityEngine;

public class Rock : BaseObject
{
    public bool coconut = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canHold = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mud")
        {
            coconut = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(other.gameObject);
        }
    }
}
