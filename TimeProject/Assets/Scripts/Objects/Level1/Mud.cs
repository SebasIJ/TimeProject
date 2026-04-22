using UnityEngine;

public class Mud : BaseObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract)
        {
            UIManager.Instance.dialog.DialogRequest("Observation\n Mud and  coconuts are the same color");
            plyInteract = false;            
        }        
    }
}
