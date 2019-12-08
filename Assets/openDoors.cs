using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoors : MonoBehaviour
{

    public Transform lDoor;
    public Transform rDoor;
    private Quaternion initialL;
    private Quaternion initialR;

    private void Start(){
        initialL = lDoor.rotation;
        initialR = rDoor.rotation;
    }
    public void Open(){
        StartCoroutine("animateOpen");
    }

    public void Close(){
        lDoor.rotation = initialL;
        rDoor.rotation = initialR;
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
