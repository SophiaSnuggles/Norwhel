using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFace : MonoBehaviour {
	public GameObject target;

	void Start(){
		//target = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void FixedUpdate () {
		transform.forward = target.transform.forward;
    }
}