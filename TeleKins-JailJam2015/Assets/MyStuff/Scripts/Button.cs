using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{
    private bool open = false;
    public GameObject Reaction;
    public Animation anim;
    public GameObject Reaction02;
    public Animation anim02;

    public bool IsOpen
    {
        get
        {
            return open;
        }
    }

    void Start() {

        anim = Reaction.GetComponent<Animation>();
        anim02 = Reaction02.GetComponent<Animation>();
    }

	void OnTriggerEnter(Collider intruder)
    {
        if(intruder.transform.tag == "Interactable")
        {
            print("Woop");
            open = true;
            anim.Play();
            anim02.Play();
        }
    }
    void OnTriggerExit(Collider intruder)
    {
        if (intruder.transform.tag == "Interactable")
        {
            open = false;
        }
    }
}
