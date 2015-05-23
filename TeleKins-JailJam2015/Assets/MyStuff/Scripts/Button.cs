using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{
    private bool open = false;

    public bool IsOpen
    {
        get
        {
            return open;
        }
    }

	void OnTriggerEnter(Collider intruder)
    {
        if(intruder.transform.tag == "Cube")
        {
            open = true;
        }
    }
    void OnTriggerExit(Collider intruder)
    {
        if (intruder.transform.tag == "Cube")
        {
            open = false;
        }
    }
}
