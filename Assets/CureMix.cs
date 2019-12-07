using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureMix : MonoBehaviour
{
    public Material purpleMat;
    public Material orangeMat;
    public Material greenMat;
    public Material partialMat;
    public Material CureMat;
    public GameObject fLiquid;
    public GameObject LiquidParent;
    public GameObject ParticleEffect;

    private int mat1;
    private int mat2;

    void Start()
    {
        mat1 = 0;
        mat2 = 0;
    }

    private void OnParticleCollision(GameObject other){
        if(mat1 == 0){
            if(other.GetComponent<Renderer>().material.name.Contains(purpleMat.name)){
                ChangeMaterial(purpleMat);
                mat1 = 1;
            }
            else if(other.GetComponent<Renderer>().material.name.Contains(greenMat.name)){
                ChangeMaterial(greenMat);
                mat1 = 2;
            }
            else if(other.GetComponent<Renderer>().material.name.Contains(orangeMat.name)){
                ChangeMaterial(orangeMat);
                mat1 = 3;
            }
            StartCoroutine("FillThird");
        }
        else if(mat2 == 0){
            if(other.GetComponent<Renderer>().material.name.Contains(purpleMat.name) && mat1 != 1){
                StartCoroutine("ChangeColor", partialMat);
                StartCoroutine("FillTwoThird");
                mat2 = 1;
            }
            if(other.GetComponent<Renderer>().material.name.Contains(greenMat.name) && mat1 != 2){
                StartCoroutine("ChangeColor", partialMat);
                StartCoroutine("FillTwoThird");
                mat2 = 2;
            }
            if(other.GetComponent<Renderer>().material.name.Contains(orangeMat.name)&& mat2 != 3){
                StartCoroutine("ChangeColor", partialMat);
                StartCoroutine("FillTwoThird");
                mat2 = 3;
            }
        }
        else{
            if(other.GetComponent<Renderer>().material.name.Contains(purpleMat.name) && mat1 != 1){
                StartCoroutine("ChangeColor", CureMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(greenMat.name) && mat1 != 2 && mat2 != 2){
                StartCoroutine("ChangeColor", CureMat);
                StartCoroutine("FillFull");
            }
            if(other.GetComponent<Renderer>().material.name.Contains(orangeMat.name)&& mat1 != 3 && mat2 != 3){
                StartCoroutine("ChangeColor", CureMat);
                StartCoroutine("FillFull");
            }
        }
    }

    void ChangeMaterial(Material mat){
        fLiquid.SetActive(true);
        fLiquid.GetComponent<Renderer>().material = mat;
        ParticleEffect.GetComponent<Renderer>().material = mat;
    }

    IEnumerator FillThird() 
    {
        for (float y = LiquidParent.transform.localScale.y; y <=.3f; y+=.01f) 
        {
            LiquidParent.transform.localScale += new Vector3(0, .01f, 0);
            yield return null;
        }
        yield break;
    }

    IEnumerator FillTwoThird() 
    {
        for (float y = LiquidParent.transform.localScale.y; y <=.6f; y+=.01f) 
        {
            LiquidParent.transform.localScale += new Vector3(0, .01f, 0);
            yield return null;
        }
        yield break;
    }

        IEnumerator FillFull() 
    {
        for (float y = LiquidParent.transform.localScale.y; y <=.75f; y+=.01f) 
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
