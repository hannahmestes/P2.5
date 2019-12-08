using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SkinnedMeshRenderer lHand;
    public SkinnedMeshRenderer rHand;
    public Material greenHands;
    public Material DeadHead;
    public float timeLimit;
    public GameObject HeadBubble;
    public TextMesh GameOverText;
    public TextMesh TimerText;
    public AudioSource Radio;
    public ParticleSystem Confetti;
    public openDoors FrontDoors;
    public AudioSource Success;

    private Material normalHands;
    private bool hasConsumedCure = false;
    private bool timerOn = false;
    private float Timer;    

    void Start(){
        normalHands = lHand.material;
    }

    void Update()
    {
        if (timerOn) {
            Timer -= Time.deltaTime;
           
            if(Timer <= 0){
                timerOn = false;
                timerEnded();
                TimerText.text = "00:00";
            }
            float m = Timer % 3600;
            string minutes = ((int)m / 60).ToString("00");
            string seconds = (m % 60).ToString("00");

            TimerText.text = minutes + ":" + seconds;
        }
    }

    public void StartTimer()
    {
        Timer = timeLimit;
        timerOn = true;
        StartCoroutine(turnHands(greenHands, 100*timeLimit));
    }
    
    public void StartAudio()
    {
        Radio.Play();
    }

    void timerEnded()
    {
        GameOverText.text = "Game Over";
        StartCoroutine("Lose");
        StopCoroutine("turnHands");
    }

    void resetEverything(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void doorOpened(){
        if(hasConsumedCure){
            FrontDoors.Open();
            StartCoroutine("Win");
        }
        else{
            GameOverText.text = "You are infected \n Game over";
            StartCoroutine("Lose");      
        }
    }

    public void TakeCure(){
        hasConsumedCure = true;
        timerOn = false;
        StopCoroutine("turnHands");
        StartCoroutine(turnHands(normalHands, 50f));
    }

    private IEnumerator Win(){
        Success.Play();
        Confetti.Play();
        yield return new WaitForSeconds(5);
        resetEverything();
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

    public IEnumerator Lose(){
        lHand.gameObject.SetActive(false);
        rHand.gameObject.SetActive(false);
        Material start = HeadBubble.GetComponent<Renderer>().material;
        float elapsedTime = 0;
        int duration = 5;
        while (elapsedTime < duration)
        {
            HeadBubble.GetComponent<Renderer>().enabled = true;
            HeadBubble.GetComponent<Renderer>().material.Lerp(start, DeadHead, (elapsedTime / (10*duration)));
            GameOverText.color = new Color(255,255,255, (elapsedTime*255/duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        resetEverything();
        yield break;
    }

    public bool TimerOn(){
        return timerOn;
    }

}
