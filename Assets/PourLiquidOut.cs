using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourLiquidOut : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public GameObject interactableParent;
    public GameObject liquid;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(liquid.transform.localScale.y > 0 &&
        interactableParent.transform.rotation.z > .69 || 
        interactableParent.transform.rotation.z < -.69 ||
        interactableParent.transform.rotation.x > .69 ||
        interactableParent.transform.rotation.x < -.69){
            particleEffect.Play(true);
            float y = liquid.transform.localScale.y;
            liquid.transform.localScale.Set(1, y-0.001f, 1);
        }
        else{
            particleEffect.Stop(true);
        }
    }
}
