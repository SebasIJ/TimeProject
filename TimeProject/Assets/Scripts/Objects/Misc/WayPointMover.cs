using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    public bool move = false;
    private bool rested = true;
    public bool loop = false;
    private int index = 0;
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move && rested)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[index].position, Time.deltaTime * speed);

            if(transform.position == positions[index].position)
            {
                if(positions.Count - 1 > index)
                {
                    index++;
                    StartCoroutine(PauseTime());
                }
                else if(loop)
                {
                    index = 0;
                    StartCoroutine(PauseTime());
                }
                else
                {
                    move = false;
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
