using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SkinnedMeshRenderer lHand;
    public SkinnedMeshRenderer rHand;
    public Material greenHands;
    public Material Transparent;
    public Material DeadHead;
    public float timeLimit;
    public GameObject HeadBubble;
    public PauseMenuLogic menu;
    public TextMesh GameOverText;
    public TextMesh TimerText;
    public AudioSource Radio;

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
        StartCoroutine(turnHands(greenHands, 1000*timeLimit));
    }
    
    public void StartAudio()
    {
        Radio.Play();
    }

    void timerEnded()
    {
        HeadBubble.SetActive(true);
        StartCoroutine("TurnHead", DeadHead);
        StopCoroutine("turnHands");
        StartCoroutine("gameOver");
        lHand.gameObject.SetActive(false);
        rHand.gameObject.SetActive(false);
    }

    void resetEverything(){
        if(Radio.isPlaying) Radio.Stop();
        StartCoroutine(turnHands(normalHands, 1f));
        lHand.gameObject.SetActive(true);
        rHand.gameObject.SetActive(true);
        GameOverText.color = new Color(255,255,255,0);
        HeadBubble.GetComponent<Renderer>().material = Transparent;
        HeadBubble.SetActive(false);
        Timer = timeLimit;
    }

    public bool canExit(){
        return hasConsumedCure;
    }

    public void TakeCure(){
        hasConsumedCure = true;
        timerOn = false;
        StopCoroutine("turnHands");
        StartCoroutine(turnHands(normalHands, 50f));
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
            HeadBubble.GetComponent<Renderer>().enabled = true;
            HeadBubble.GetComponent<Renderer>().material.Lerp(start, color, (elapsedTime / duration));
            GameOverText.color = new Color(255,255,255, (elapsedTime*255/duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        resetEverything();
        menu.ResetGame();
        yield break;
    }

    public bool TimerOn(){
        return timerOn;
    }

}
