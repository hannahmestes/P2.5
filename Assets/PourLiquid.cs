using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourLiquid : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public GameObject interactableParent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(interactableParent.transform.rotation.z > .69 || 
        interactableParent.transform.rotation.z < -.69 ||
        interactableParent.transform.rotation.x > .69 ||
        interactableParent.transform.rotation.x < -.69){
            particleEffect.Play(true);
        }
        else{
            particleEffect.Stop(true);
            //particleEffect.Clear(true);
        }
    }
}
