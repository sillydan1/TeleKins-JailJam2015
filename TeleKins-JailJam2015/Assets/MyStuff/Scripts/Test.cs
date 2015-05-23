using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    private float whatever = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        whatever += Time.deltaTime * 10;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(whatever), transform.position.z);
	}
}
