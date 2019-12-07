using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoors : MonoBehaviour
{

    public Transform lDoor;
    public Transform rDoor;

    public void Open(){
        StartCoroutine("animateOpen");
    }

    IEnumerator animateOpen(){
        float elapsedTime = 0;
        while (elapsedTime < 130)
        {
            lDoor.Rotate(new Vector3(0,1f,0), Space.Self);
            rDoor.Rotate(new Vector3(0,-1f,0), Space.Self);
            elapsedTime ++;
            yield return null;
        }
    }
}
