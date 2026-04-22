using UnityEngine;

public class LevelStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerScript.instance.transform.position = new Vector3(transform.position.x, PlayerScript.instance.transform.position.y, transform.position.z);
        PlayerScript.instance.playerRb.linearVelocity = Vector3.zero;
        Destroy(gameObject);
    }

}
