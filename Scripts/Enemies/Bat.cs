using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{

    public bool isFollowing;

    public float xSpeed;
    public float ySpeed;

    public float followRadius; // base radius that will trigger the bat move towards character when entered.
    public float duringFollowRadius; // a bigger radius that will be the current follow radius after the bat starts following player
    private float initialFollowRadius; // an initial value of the radius to go back to after the bat is no longer following player
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = followRadius;
        initialFollowRadius = followRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            if (transform.position.x < playerController.instance.transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + (xSpeed * Time.deltaTime), transform.position.y, transform.position.z);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (transform.position.x >= playerController.instance.transform.position.x + 0.5f)
            {
                transform.position = new Vector3(transform.position.x - (xSpeed * Time.deltaTime), transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            if (transform.position.y < playerController.instance.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + +(ySpeed * Time.deltaTime), transform.position.z);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (transform.position.y >= playerController.instance.transform.position.y + 0.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (ySpeed * Time.deltaTime), transform.position.z);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    private void OnDrawGizmosSelected() //Gizmo to show current follow radius
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRadius);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isFollowing)
        {
            followRadius = duringFollowRadius;
            GetComponent<CircleCollider2D>().radius = followRadius;
            isFollowing = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isFollowing)
        {
            followRadius = initialFollowRadius;
            GetComponent<CircleCollider2D>().radius = followRadius;
            isFollowing = false;
        }
    }
}
