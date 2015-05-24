using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
    public bool usingLegacey = false;
    private bool isOpen;
    public Button[] myButtons;

    void Update()
    {
        int amountOfYes = 0;
        foreach(Button butt in myButtons)
        {
            if (butt.IsOpen)
                amountOfYes++;
        }
        if(amountOfYes >= myButtons.Length)
        {
            if (!isOpen)
            {
                if (usingLegacey)
                {
                    GetComponent<Animation>().CrossFade("Open");
                }
                else
                {
                    GetComponent<Animator>().SetBool("Open", true);
                }
                isOpen = true;
            }
        }
        else if(isOpen)
        {
            if (usingLegacey)
            {
                GetComponent<Animation>().CrossFade("Close");
            }
            else
            {
                GetComponent<Animator>().SetBool("Close", true);
            }
            isOpen = false;
        }
    }
}
