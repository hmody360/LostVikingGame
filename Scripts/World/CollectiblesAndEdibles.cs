using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesAndEdibles : MonoBehaviour
{
    public bool isCoin;
    public bool isKey;
    public bool isEdible;

    public int coinAmount;
    public int healAmount;

    private void OnTriggerEnter2D(Collider2D other) //Using Trigger instead of Collision because collision causes player to stop for a moment while trigger triggers by jus touching and passing the object.
    {
        if (other.gameObject.tag == "Player")
        {
            if (isCoin)
            {
                gameManager.instance.CollectCoin(coinAmount);
            }

            if (isKey)
            {
                gameManager.instance.CollectKey();
                gameManager.instance.UpdateCollectables();
            }
            if (isEdible)
            {
                gameManager.instance.currentHealth += healAmount;
                gameManager.instance.updateHealth();
            }
            Destroy(gameObject);
        }
    }
}
