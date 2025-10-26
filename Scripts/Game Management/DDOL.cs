using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{

    private Scene currentScene;

    // Awake is called before the Start method
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Preload"){
            DontDestroyOnLoad(this);
            SceneManager.LoadScene(1);
        }
        
    }
}
