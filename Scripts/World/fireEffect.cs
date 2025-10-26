using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class fireEffect : MonoBehaviour
{

    public float xtime;
    public float ytime;

    public float timer;

    public float xrange;
    public float yrange;

    public bool timerFix;


    // Update is called once per frame
    void Update()
    {
        

        if (timerFix)
        {
            timer = Random.Range(xtime, ytime);
            timerFix = false;
        }
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = Random.Range(xrange, yrange);
            timerFix = true;
        }
    }
}
