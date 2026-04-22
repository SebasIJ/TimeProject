using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    public bool move = false;
    private bool rested = true;
    private bool leftShovel = false;
    public bool loop = false;
    private int index = 0;
    public float speed;

    public GameObject shovel;
    public GameObject objectHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.timerMinutes == 1 && GameManager.instance.timerSeconds == 40)
        {
            move = true;
        }

        if (move && rested)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[index].position, Time.deltaTime * speed);

            if (transform.position == positions[index].position)
            {
                if (positions.Count - 1 > index)
                {
                    index++;
                    StartCoroutine(PauseTime());
                }
                else if (loop)
                {
                    index = 0;
                    StartCoroutine(PauseTime());
                }
                else
                {
                    move = false;
                }

                if (!leftShovel && shovel.transform.parent == transform)
                {
                    shovel.transform.SetParent(objectHolder.transform);
                    shovel.transform.position = new Vector3(shovel.transform.position.x, 0.3f, shovel.transform.position.z);
                    shovel = null;
                    leftShovel = true;
                }
            }
        }
    }

    IEnumerator PauseTime()
    {
        rested = false;
        yield return new WaitForSeconds(1);
        rested = true;
    }
}
