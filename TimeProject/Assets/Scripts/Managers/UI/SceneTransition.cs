using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneTransition : MonoBehaviour
{
    public GameObject transition;
    public GameObject transitionIMG;
    public Sprite finalSprite;
    public Sprite firstSprite;

    public bool loading = false;
    private bool newScene = false;
    private bool quitting = false;
    private int sceneIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transition.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!loading)
        {
            if(transitionIMG.GetComponent<UnityEngine.UI.Image>().color.a == 0)
            {
                transition.SetActive(false);
                loading = true;
            }
        }
        else if(newScene)
        {
            if (transitionIMG.GetComponent<UnityEngine.UI.Image>().color.a == 1)
            {
                loading = false;
                newScene = false;
                transitionIMG.GetComponent<Animator>().SetBool("LeavingScene", false);
                SceneManager.LoadScene(sceneIndex);
            }
        }
        else if (quitting)
        {            
            if (transitionIMG.GetComponent<UnityEngine.UI.Image>().color.a == 1)
            {
                Application.Quit();
            }
        }
    }

    public void SceneLoad(int index)
    {
        sceneIndex = index;
        transition.SetActive(true);
        transitionIMG.GetComponent<Animator>().SetBool("LeavingScene", true);
        newScene = true; 
    }

    public void QuitGame()
    {
        transition.SetActive(true);
        transitionIMG.GetComponent<Animator>().SetBool("LeavingScene", true);
        quitting = true;
    }
}
