using UnityEngine;

public class TreeCheck : MonoBehaviour
{
    int treeTotal = 0;
    public GameObject disk;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreeInteract()
    {
        treeTotal++;

        switch (treeTotal)
        {
            case 1:
                UIManager.Instance.dialog.DialogRequest("This is a Tree");
                break;
            case 2:
                UIManager.Instance.dialog.DialogRequest("This is a second Tree");
                break;
            case 3:
                UIManager.Instance.dialog.DialogRequest("The third tree revealed a hidden disk");
                disk.SetActive(true);
                Destroy(gameObject);
                break;
        }
    }
}
