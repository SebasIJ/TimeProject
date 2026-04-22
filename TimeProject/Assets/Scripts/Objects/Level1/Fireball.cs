using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Sprite lastSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<SpriteRenderer>().sprite == lastSprite)
        {
            transform.position = new Vector3(PlayerScript.instance.transform.position.x, 10, PlayerScript.instance.transform.position.z);
            transform.rotation = PlayerScript.instance.transform.rotation;
            GetComponent<Animator>().SetBool("Explode", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Animator>().SetBool("Explode", true);
    }
}
