using UnityEngine;
using UnityEngine.SceneManagement;

public class Flower : BaseObject
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
            UIManager.Instance.dialog.DialogRequest("Prehistoric Lava Flower\nGrows in rivers\nand blooms under\nvolcanic eruptions");
            UIManager.Instance.dialog.DialogRequest("Analizing...\nUpdating TIME_REWIND.EXE...\nIgnoring Time Period");
            UIManager.Instance.dialog.DialogRequest("That is all the content in this build\nThank you for playing");
            

            for (int i = 0; i < GameManager.instance.levelList.Count; i++)
            {
                if (GameManager.instance.levelList[i].sceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    GameManager.level temp = GameManager.instance.levelList[i];
                    temp.cleared = true;
                    GameManager.instance.levelList[i] = temp;
                }
            }

            Destroy(gameObject);
            PlayerScript.instance.DestroyingObject();
        }
    }
}
