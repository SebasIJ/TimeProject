using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI timerMinutes;
    public TextMeshProUGUI timerSeconds;
    public TextMeshProUGUI battery;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.level0Clear)
        {
            battery.text = GameManager.instance.battery.ToString();
        }

        if(GameManager.instance.timerMinutes >= 0 && GameManager.instance.timerSeconds >= 0)
        {
            timerMinutes.text = GameManager.instance.timerMinutes.ToString();
            timerSeconds.text = GameManager.instance.timerSeconds.ToString();
        }
        
    }
}
