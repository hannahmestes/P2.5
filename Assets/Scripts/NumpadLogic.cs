using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadLogic : MonoBehaviour
{
    public string winCode ="3862";
    protected string currentCode = "1234";
    public UnityEvent onWin;
    public TMPro.TextMeshProUGUI display;
    void Awake()
    {
        currentCode = display.text;
    }

    public void ButtonPressed( int val){
        currentCode = currentCode.Substring(1) + val.ToString();
        display.text = currentCode;

        if ( currentCode == winCode){
            Debug.Log("winner!!!!!");
            if(onWin != null){
                onWin.Invoke();
            }
        }
    }

   
}
