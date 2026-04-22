using UnityEngine;

public class BoxKey : BaseObject
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
            GameManager.instance.level0Key = true;
            Destroy(gameObject);
            PlayerScript.instance.DestroyingObject();
        }

        if(GetComponent<SpriteRenderer>().color.a < 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, GetComponent<SpriteRenderer>().color.a + 0.01f);
        }
    }
}
