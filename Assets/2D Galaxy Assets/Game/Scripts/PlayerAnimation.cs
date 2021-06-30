using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			animator.SetBool("Turn_Left", true);
			animator.SetBool("Turn_Right", false);
		} else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {
			animator.SetBool("Turn_Left", false);
			animator.SetBool("Turn_Right", false);
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
			animator.SetBool("Turn_Right", true);
			animator.SetBool("Turn_Left", false);
		}else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
			animator.SetBool("Turn_Right", false);
			animator.SetBool("Turn_Left", false);
		}
	}
}
