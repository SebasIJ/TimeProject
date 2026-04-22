using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewindTime
{
    int finalIndex = 0;

    public void Rewind()
    {
        GameManager.instance.secondLenght = 1;
        GameManager.instance.timerMinutes = 2;
        GameManager.instance.timerSeconds = 0;
        ChooseLevel();
    }

    public void ChooseLevel()
    {
        if(GameManager.instance.level0Clear)
        {
            bool allCleared = true;

            foreach(GameManager.level level in GameManager.instance.levelList)
            {
                if (!level.cleared)
                {
                    allCleared = false;
                }
            }

            if(allCleared)
            {
                UIManager.Instance.transition.SceneLoad(finalIndex);
            }
            else
            {
                RandomLevel();
            }
        }
        else
        {
            UIManager.Instance.transition.SceneLoad(GameManager.instance.levelList[0].sceneIndex);       
        }
    }

    void RandomLevel()
    {
        GameManager.level newLevel = GameManager.instance.levelList[Random.Range(0,GameManager.instance.levelList.Count)];

        if (newLevel.cleared)
        {
            RandomLevel();
        }
        else
        {
            UIManager.Instance.transition.SceneLoad(newLevel.sceneIndex);
        }
    }

}
