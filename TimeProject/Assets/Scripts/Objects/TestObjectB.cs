using UnityEngine;

public class TestObjectB : BaseObject
{
    public Transform dest;
    public bool activatedText = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest.position, 5 * Time.deltaTime);

            if (!activatedText)
            {
                UIManager.Instance.dialog.DialogRequest("Dialog test B\nSecond Line");
                activatedText = true;
            }
        }
    }
}
