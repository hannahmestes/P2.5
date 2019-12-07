using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool hasConsumedCure = false;
    private Material normalHands;
    public SkinnedMeshRenderer lHand;
    public SkinnedMeshRenderer rHand;
    public Material greenHands;
    public Material cureMat;
    public GameObject HeadBubble;
    public Material Transparent;
    public Material DeadHead;
    public float timeLimit = 300.0f;
    public PauseMenuLogic menu;
    private bool timerOn = false;
    public Material GameOverText;


    void Start(){
        normalHands = lHand.material;
    }

    void DisableEverything(){

    }

    void StartTimer()
    {
        StartCoroutine(turnHands(greenHands, 100*timeLimit));
        timerOn = true;
    }
 
    void Update(){
    if (timerOn) timeLimit -= Time.deltaTime;
        if (timeLimit <= 0.0f)
        {
            timerEnded();
        }
    }
    
    void timerEnded()
    {
        HeadBubble.SetActive(true);
        StartCoroutine("TurnHead", DeadHead);
        StopCoroutine("turnHands");
        StartCoroutine("gameOver");
        lHand.gameObject.SetActive(false);
        rHand.gameObject.SetActive(false);
        // move player to start
    }

    void resetEverything(){
        lHand.material = normalHands;
        rHand.material = normalHands;
        lHand.gameObject.SetActive(true);
        rHand.gameObject.SetActive(true);
        GameOverText.SetFloat(ShaderUtilities.ID_FaceDilate, -1);
        HeadBubble.GetComponent<Renderer>().material = Transparent;
        HeadBubble.SetActive(false);
    }

    public bool canExit(){
        return hasConsumedCure;
    }

    private void OnParticleCollision(GameObject other){
        if(other.GetComponent<Renderer>().material.name.Contains(cureMat.name)){
                hasConsumedCure = true;
                timerOn = false;
                StopCoroutine("turnHands");
                StartCoroutine(turnHands(normalHands, 50f));
         }
    }

    

    public IEnumerator gameOver(){
        float duration = 5;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            GameOverText.SetFloat(ShaderUtilities.ID_FaceDilate, (elapsedTime/duration)-1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    public IEnumerator turnHands(Material color, float duration){
        float elapsedTime = 0;
        Material start = lHand.material;
        while (elapsedTime < duration)
        {
            lHand.material.Lerp(start, color, (elapsedTime / duration));
            rHand.material.Lerp(start, color, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    public IEnumerator TurnHead(Material color){
        Material start = HeadBubble.GetComponent<Renderer>().material;
        float elapsedTime = 0;
        int duration = 500;
        while (elapsedTime < duration)
        {
            HeadBubble.GetComponent<Renderer>().material.Lerp(start, color, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

}
