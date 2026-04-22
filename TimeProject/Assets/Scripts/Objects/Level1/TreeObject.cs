using UnityEngine;

public class TreeObject : BaseObject
{
    public TreeCheck checker;
    bool treeInteract = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract && !treeInteract && !GameManager.instance.levelList[0].diskCollect)
        {
            checker.TreeInteract();
            treeInteract = true;
        }
    }
}
