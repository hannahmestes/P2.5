using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Material Cure;
    public GameManager GameManager;

    private void OnParticleCollision(GameObject other){
        if(other.GetComponent<Renderer>().material.name.Contains(Cure.name)){
                GameManager.TakeCure();
                Debug.Log("HERE");
         }
    }
}
