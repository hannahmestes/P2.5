using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private TextMesh uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    //private bool canCount = true;
    //private bool doOnce = false;

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f) {
            timer -= Time.deltaTime;


           
            float m = timer % 3600;
            string minutes = ((int)m / 60).ToString("00");
            string seconds = (m % 60).ToString("00");

            uiText.text = minutes + ":" + seconds;
        }

        else if(timer <= 0.0f)
        {
            uiText.text = "00:00";
        }
    }


    // public void ResetBtn() 
    // {
    //     timer = mainTimer;
    //     canCount = true;
    //     doOnce = false;

    // }
}
