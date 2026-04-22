using UnityEngine;

public class Entrance : BaseObject
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
            UIManager.Instance.dialog.DialogRequest("Today's password:\nblue + yellow");
            plyInteract = false;
        }
    }
}
