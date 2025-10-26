using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{

    private Animator theAnim;
    private bool canOpenChest;
    private bool isChestOpen;
    public GameObject treasure;
    // Start is called before the first frame update
    void Start()
    {
        theAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenChest && gameManager.instance.keyAmount >= 1 && !isChestOpen)
        {
            isChestOpen = true;
            theAnim.SetBool("isChestOpen", isChestOpen);
            Instantiate(treasure, transform.position, Quaternion.identity);
            gameManager.instance.UseKey();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            canOpenChest = true;
        }
        
    }

    private void OnTriggerEExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpenChest = false;
        }
    }
}
