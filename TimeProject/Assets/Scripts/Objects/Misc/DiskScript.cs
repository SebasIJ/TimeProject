using UnityEngine;
using UnityEngine.SceneManagement;

public class DiskScript : BaseObject
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

            if (!GameManager.instance.rewindDisk)
            {

                GameManager.instance.rewindDisk = true;
                UIManager.Instance.dialog.DialogRequest("Installing\ntime_Rewind.exe");
                UIManager.Instance.dialog.DialogRequest("You can now execute\nTime Rewind Program\n version 0.0001");
                UIManager.Instance.dialog.DialogRequest("Press X key to\nexecute programs");               

            }
            else if (!GameManager.instance.hintDisk)
            {

                GameManager.instance.hintDisk = true;
                UIManager.Instance.dialog.DialogRequest("Installing\nHint_analysis.exe");
                UIManager.Instance.dialog.DialogRequest("Analyze your area\nObtain helpful info\nAid Unit Objectives");
                UIManager.Instance.dialog.DialogRequest("Press X key to\nexecute programs");

            }
            else if (!GameManager.instance.slowDisk)
            {

                GameManager.instance.hintDisk = true;
                UIManager.Instance.dialog.DialogRequest("Installing\nSlow_Time.exe");
                UIManager.Instance.dialog.DialogRequest("Improve unit efficiency\ntime will appear to double\nAid Unit Objectives");
                UIManager.Instance.dialog.DialogRequest("Press X key to\nexecute programs");

            }

            for(int i = 0; i < GameManager.instance.levelList.Count; i++)
            {
                if(GameManager.instance.levelList[i].sceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    GameManager.level temp = GameManager.instance.levelList[i];
                    temp.diskCollect = true;
                    GameManager.instance.levelList[i] = temp;
                }
            }

            Destroy(gameObject);
            PlayerScript.instance.DestroyingObject();
        }
    }
}
