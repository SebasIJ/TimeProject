using UnityEngine;

public class FollowLight : MonoBehaviour
{
    public float intensity;
    public new Light light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.instance.canMove)
        {
            light.intensity = intensity;
            transform.position = new Vector3(PlayerScript.instance.transform.position.x, transform.position.y, PlayerScript.instance.transform.position.z);
        }
        else
        {
            light.intensity = 0;
        }
    }
}
