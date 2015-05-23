﻿using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
    private Camera myCam;
    public float maxDist = 10;
    public float pushForce = 2;
    private LineRenderer myBeam;
    private bool isPulling;
    private Interactable myTarget;
    private Vector3 hitoffset;
	// Use this for initialization
	void Start () 
    {
        myBeam = transform.parent.FindChild("BeamPoint").gameObject.GetComponent<LineRenderer>();
        myCam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetButtonDown("Fire1"))
        {
            Ray myRay = myCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(myRay, out hit, maxDist))
            {
                if(hit.transform.tag == "Interactable")
                {
                    hitoffset = hit.transform.position - hit.point;
                    myBeam.SetPosition(0, myBeam.transform.position);
                    myBeam.SetPosition(1, hit.transform.position);
                    myTarget = hit.transform.GetComponent<Interactable>();
                    myTarget.MoveTowards(transform.position + (transform.forward * 0.05f));
                    isPulling = true;
                    if(myTarget.myType == MoveType.freeMovement)
                    {
                        //Disable the gravity.
                        myTarget.GetComponent<Rigidbody>().useGravity = false;
                        myTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
            }
            
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            StopPulling();
        }

        if(isPulling)
        {
            if (myTarget.myType != MoveType.triggered)
            {
                if (myTarget.myType == MoveType.lockedAxis)
                {
                    myTarget.MoveTowards(transform.position + (transform.forward * maxDist));
                    myBeam.SetPosition(0, myBeam.transform.position);
                    myBeam.SetPosition(1, myTarget.transform.position + hitoffset);
                }
                else
                {
                    myTarget.MoveTowards(transform.position + (transform.forward * maxDist));
                    myBeam.SetPosition(0, myBeam.transform.position);
                    myBeam.SetPosition(1, myTarget.transform.position);
                }
            }

            if(Input.GetButtonDown("Fire2"))
            {
                if(myTarget.myType == MoveType.freeMovement)
                {
                    
                    myTarget.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce);
                    StopPulling();
                }
            }
        }
	}
    void StopPulling()
    {
        isPulling = false;
        myBeam.SetPosition(0, Vector3.zero);
        myBeam.SetPosition(1, Vector3.zero);
        if (myTarget != null)
        {
            if (myTarget.myType == MoveType.freeMovement)
            {
                //Disable the gravity.
                myTarget.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        myTarget = null;
    }
}
