using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game manager is a singleton that will manage the countdown timer and keep track of completed levels
    //and key items obtained
    public static GameManager instance { get; private set; }

    public int timerSeconds;
    public int timerMinutes;
    public int secondLenght = 1;
    public int battery = 20;
    private float counter = 0;

    public bool timerGo = false;
    public bool gameStart = false;

    //Level progress
    public bool level0Clear = false;

    [System.Serializable]
    public struct level { public int sceneIndex; public bool cleared; public bool diskCollect; };
    
    public List<level> levelList;

    //Inventory booleans
    public bool level0Key = false;
    //public bool level1Key = false;
    //public bool level2Key = false;
    //public bool level3Key = false;
    public bool rewindDisk = false;
    public bool hintDisk = false;
    public bool slowDisk = false;


    public bool TimerGo
    {
        get { return timerGo; }
        set { timerGo = value; }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            timerGo = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerLogic();
    }


    void TimerLogic()
    {
        if (timerGo)
        {
            counter += Time.deltaTime;
        }

        if (counter >= secondLenght)
        {
            counter = 0;

            if (timerMinutes >= 0)
            {
                if (timerSeconds > 0)
                {
                    timerSeconds--;
                }
                else
                {
                    timerSeconds = 59;
                    timerMinutes--;
                }
                //Debug.Log(timerMinutes + " : " + timerSeconds);
            }
            else
            {
                Debug.Log("Kaboom");
                UIManager.Instance.lose.GameOver();
            }
        }
    }
}
