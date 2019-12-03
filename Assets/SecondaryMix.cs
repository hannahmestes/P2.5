using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryMix : MonoBehaviour
{
    public Material purpleMat;
    public Material orangeMat;
    public Material greenMat;
    public Material redMat;
    public Material blueMat;
    public Material yellowMat;
    public GameObject fLiquid;
    public GameObject LiquidParent;
    public GameObject ParticleEffect;

    private int currentMat;

    void Start()
    {
        currentMat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other){
        if(currentMat == 0){
            if(other.GetComponent<Renderer>().material.name.Contains(blueMat.name)){
                ChangeMaterial(blueMat);
                currentMat = 1;
            }
            else if(other.GetComponent<Renderer>().material.name.Contains(redMat.name)){
                ChangeMaterial(redMat);
                currentMat = 2;
            }
            else if(other.GetComponent<Renderer>().material.name.Contains(yellowMat.name)){
                ChangeMaterial(yellowMat);
                currentMat = 3;
            }
            StartCoroutine("FillHalf");
        }
        else if(LiquidParent.transform.localScale.y<=.6){
            if(other.GetComponent<Renderer>().material.name.Contains(blueMat.name) && currentMat == 2){
                StartCoroutine("ChangeColor", purpleMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(blueMat.name) && currentMat == 3){
                StartCoroutine("ChangeColor", greenMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(redMat.name)&& currentMat == 1){
                StartCoroutine("ChangeColor", purpleMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(redMat.name)&& currentMat == 3){
                StartCoroutine("ChangeColor", orangeMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(yellowMat.name)&& currentMat == 2){
                StartCoroutine("ChangeColor", orangeMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(yellowMat.name)&& currentMat == 1){
                StartCoroutine("ChangeColor", greenMat);
                StartCoroutine("FillFull");
            }
        }
    }

    void ChangeMaterial(Material mat){
        fLiquid.SetActive(true);
        fLiquid.GetComponent<Renderer>().material = mat;
        ParticleEffect.GetComponent<Renderer>().material = mat;
    }

    IEnumerator FillHalf() 
    {
        for (float y = LiquidParent.transform.localScale.y; y <=.5f; y+=.01f) 
        {
            LiquidParent.transform.localScale += new Vector3(0, .01f, 0);
            yield return null;
        }
        yield break;
    }

        IEnumerator FillFull() 
    {
        for (float y = LiquidParent.transform.localScale.y; y <=.65f; y+=.01f) 
        {
            LiquidParent.transform.localScale += new Vector3(0, .01f, 0);
            yield return null;
        }
        yield break;
    }

     IEnumerator ChangeColor(Material mat)
    {
        float elapsedTime = 0;
        Material start = fLiquid.GetComponent<Renderer>().material;
        ParticleEffect.GetComponent<Renderer>().material = mat;
        while (elapsedTime < 50)
        {
            fLiquid.GetComponent<Renderer>().material.Lerp(start, mat, (elapsedTime / 50));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
