using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
public class AnimatorScript : MonoBehaviour {

private Animator anim;
private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer

	// Use this for initialization
	void Start () {
	
	anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.GetMouseButtonDown(1)){
			anim.SetBool("Pull", true);
			anim.SetBool("Hover", true);
		}
		else {
			anim.SetBool("Pull", false);
		}
		if (Input.GetMouseButtonUp(1)){
			anim.SetBool("Hover", false);
		}
		if (Input.GetMouseButtonDown(0) && anim.GetBool("Hover") == true) {
			anim.SetBool("Push", true);
		}
		else {
			anim.SetBool("Push", false);
		}

		if (Input.GetMouseButtonDown(0)){
			anim.SetBool("Push", true);
		}
		else {
			anim.SetBool("Push", false);
		}
		if (Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool("Jump", true);
		}
		else {
			anim.SetBool("Jump", false);
		}
	}
}
