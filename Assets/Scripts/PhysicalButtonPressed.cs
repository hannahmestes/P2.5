using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButtonPressed : MonoBehaviour
{
	public UnityEvent onPressed;
	protected bool lastState = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetState(bool state){
        if( state && !lastState && onPressed != null){
            Debug.log("Button Pressed");
            onPressed.Invoke();
        }
        lastState = state;
    }
}
