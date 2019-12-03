using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool hasConsumedCure = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeCure(){
        this.hasConsumedCure = true;
    }

    public bool canExit(){
        return hasConsumedCure;
    }
}
