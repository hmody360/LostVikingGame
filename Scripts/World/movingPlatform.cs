using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform start, end;

    public float platformSpeed;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == start.position)
        {
            nextPos = end.position;
        }
        if (transform.position == end.position)
        {
            nextPos = start.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, platformSpeed * Time.deltaTime);
    }
}
