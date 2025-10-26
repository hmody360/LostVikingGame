using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform start, end;

    public float speed;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<EnemiesStandard>().moveSpeed; // gets movespeed from Enemies Standard Script
        nextPos = start.position;
        transform.localScale = new Vector3(-1f, 1f, 1f); // Slime begins facing right

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == start.position)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Slime faces left
            nextPos = end.position;
        }
        if (transform.position == end.position)
        {
            nextPos = start.position;
            transform.localScale = new Vector3(-1f, 1f, 1f); // Slime faces right
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
