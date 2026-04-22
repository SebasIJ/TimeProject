using UnityEngine;

public class River : MonoBehaviour
{
    int heatLevel = 0;
    public GameObject vapor0, vapor1, vapor2, vapor3, river;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeatIncrease()
    {
        heatLevel++;

        switch(heatLevel)
        {
            case 1:
                vapor0.SetActive(true);
                break;

            case 2:
                vapor1.SetActive(true);
                vapor2.SetActive(true);
                vapor3.SetActive(true);
                break;

            case 3:
                vapor0.SetActive(false);
                vapor1.SetActive(false);
                vapor2.SetActive(false);
                vapor3.SetActive(false);
                Destroy(river);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Fireball>(out Fireball fire))
        {
            HeatIncrease();
        }
    }
}
