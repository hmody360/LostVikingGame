using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance; // Making an instance of this script to access it in other scripts.

    public GameObject thePlayer; //defining the player in the game manager.
    private Scene currentScene; //Defines the current scene being inspected by the game manager.
    private GameObject checkPlayer; // checker to see if the current scene has a player or not.

    public float maxHealth;
    public float currentHealth;
    public Image healthFill;
    public float fillAmount;
    public Text healthText;

    public int coinAmount;
    public int keyAmount;
    public Text coinText;
    public Text keyText;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        updateHealth();
        UpdateCollectables();
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene(); //this method gets the current active scene
        checkPlayer = GameObject.FindGameObjectWithTag("Player");

        if (checkPlayer == null && currentScene.name != "Preload") //checking if the player exisits in the scene and only adding them after preload (only in levels).
        {
            Instantiate(thePlayer, new Vector3(0f, 1f, 0f), Quaternion.identity); // used to create/add a new game object to the scene (here we added the player with a location, and a rotation identity(which just takes the default rotation of the object)).
        }

        //For Testing!!!
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CollectCoin(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpendCoin(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CollectKey();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseKey();
        }
    }

    public void updateHealth()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        fillAmount = currentHealth / maxHealth;
        healthFill.fillAmount = fillAmount;
        healthText.text = currentHealth + "/" + maxHealth;

        if (fillAmount <= 0.75f)
        {
            healthFill.color = UnityEngine.Color.yellow;
        }
        else if (fillAmount <= 0.25f)
        {
            healthFill.color = new UnityEngine.Color(255, 0, 0);
        }
        else
        {
            healthFill.color = UnityEngine.Color.green;
        }

        if (currentHealth == 0)
        {
            playerController.instance.DeathState();
        }
    }

    public void takeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        updateHealth();
    }

    public void CollectKey()
    {
        keyAmount++;
        UpdateCollectables();
    }

    public void UseKey()
    {
        if (keyAmount != 0)
        {
            keyAmount--;
            UpdateCollectables();
        }

    }

    public void CollectCoin(int noCoins)
    {
        coinAmount += noCoins;
        UpdateCollectables();
    }

    public void SpendCoin(int noCoins)
    {
        if (noCoins! <= coinAmount)
        {
            coinAmount -= noCoins;
            UpdateCollectables();
        }

    }

    public void UpdateCollectables()
    {
        coinText.text = coinAmount.ToString();
        keyText.text = keyAmount.ToString();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene.name); //Restart current secene after game over when button clicked
    }
}
