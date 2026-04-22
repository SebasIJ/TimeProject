using UnityEngine;

public class Dino : MonoBehaviour
{
    public bool grabRock = false;
    WayPointMover mover;

    public GameObject lava, fireball, flower, smoke;
    public River river;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<WayPointMover>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = PlayerScript.instance.transform.rotation;
        if (!mover.move && GameManager.instance.timerSeconds == 40)
        {
            mover.move = true;
        }
        else if(!mover.move && grabRock)
        {
            river.HeatIncrease();
            lava.SetActive(true);
            fireball.SetActive(true);
            flower.SetActive(true);
            smoke.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rock>(out Rock rock))
        {
            if (rock.coconut)
            {
                other.transform.SetParent(gameObject.transform);
                grabRock = true;
            }
            else
            {
                UIManager.Instance.dialog.DialogRequest("That dinosaur does not seem interested in a simple black rock");
            }
        }
    }
}
