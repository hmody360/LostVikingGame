using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesStandard : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;

    public float damage;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MapLimit")
        {
            Destroy(gameObject);
        }
    }
}
