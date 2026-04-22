using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public SceneTransition transition;
    public TitleScript title;
    public DialogManager dialog;
    public HUD hud;
    public LoseUI lose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
