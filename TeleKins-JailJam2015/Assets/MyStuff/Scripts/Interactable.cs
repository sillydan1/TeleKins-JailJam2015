using UnityEngine;
using System.Collections;
using CrackSw;

public class Interactable : MonoBehaviour 
{
    public MoveType myType;
    public Vector3 myDir;
    public float speed;
    private bool isTriggered;
    private float triggerTimer;
    public float timerTime = 2;
    private Movement playerMove;
    private LaunchPadTrigger myTrigger;

	// Use this for initialization
	void Start () 
    {
        isTriggered = false;
        triggerTimer = 0;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        if(myType == MoveType.triggered)
        {
            myTrigger = transform.FindChild("Trigger").GetComponent<LaunchPadTrigger>();
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(isTriggered)
        {
            triggerTimer += Time.deltaTime;
            if(triggerTimer >= timerTime)
            {
                if(myTrigger.IsPlayerIn)
                {
                    //Give force to the player in the desired direction
                    playerMove.Launch(myDir.normalized * speed, 3);
                    Debug.Log("JUMP!");
                    triggerTimer = 0;
                    isTriggered = false;
                }
            }
        }
	}
    public void MoveTowards(Vector3 moveTo)
    {
        if (myType == MoveType.lockedAxis)
        {
            if (Search.IsInFrontOf(transform, moveTo, myDir))
            {
                transform.Translate(myDir.normalized * speed * Time.deltaTime);
            }
            else if (Search.IsInFrontOf(transform, moveTo, -myDir))
            {
                transform.Translate(-myDir.normalized * speed * Time.deltaTime);
            }
        }
        if(myType == MoveType.freeMovement)
        {
            transform.position = Vector3.Lerp(transform.position, moveTo, Time.deltaTime * speed);
        }
        if(myType == MoveType.triggered)
        {
            //Start the timer.
            isTriggered = true;
        }
    }
    void OnDrawGizmos()
    {
        if (myType == MoveType.lockedAxis)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (myDir * 2));
        }
        else if (myType == MoveType.triggered)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + (myDir * speed));
        }
    }
}
