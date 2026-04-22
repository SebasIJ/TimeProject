using UnityEngine;

public class LoseUI : MonoBehaviour
{
    private bool lost = false;
    public GameObject loseObject;
    public GameObject loseIMG;
    public Sprite finalFrame;
    public GameObject text;
    public GameObject buttons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lost)
        {
            loseObject.SetActive(true);
            loseIMG.SetActive(true);
            if(loseIMG.GetComponent<UnityEngine.UI.Image>().sprite == finalFrame)
            {
                text.SetActive(true);
                if (text.GetComponent<UnityEngine.UI.Image>().color.a == 1)
                {
                    buttons.SetActive(true);
                }
            }
        }
    }

    public void GameOver()
    {
        lost = true;
        PlayerScript.instance.canMove = false;
    }
}
