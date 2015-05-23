using UnityEngine;
using System.Collections;

public class LaunchPadTrigger : MonoBehaviour 
{
    public bool isPlayerIn;

    public bool IsPlayerIn
    {
        get
        {
            return isPlayerIn;
        }
    }
	// Use this for initialization
	void OnTriggerEnter(Collider intruder)
    {
        if(intruder.tag == "Player")
        {
            isPlayerIn = true;
        }
    }
    void OnTriggerExit(Collider intruder)
    {
        if (intruder.tag == "Player")
        {
            isPlayerIn = false;
        }
    }
}
