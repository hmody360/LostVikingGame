using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        if (GetComponent<EnemiesStandard>())
        {
            damage = GetComponent<EnemiesStandard>().damage;
        }
    }

    private void OnTriggerStay2D(Collider2D other) //This does the below as long as the object touches and stays on the obstacle.
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.instance.takeDamage(damage);
        }
    }

}
