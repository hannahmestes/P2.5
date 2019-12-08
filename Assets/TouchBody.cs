using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBody : MonoBehaviour
{
    public GameManager GameManager;

      private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !GameManager.TimerOn()) GameManager.StartTimer();
    }
}
