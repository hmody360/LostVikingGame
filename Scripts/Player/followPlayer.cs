using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    private GameObject checkPlayer;

    // Update is called once per frame
    void Update()
    {
        checkPlayer = GameObject.FindGameObjectWithTag("Player");

        if(checkPlayer != null)
        {
            GetComponent<CinemachineVirtualCamera>().Follow = checkPlayer.transform;
        }
    }
}
