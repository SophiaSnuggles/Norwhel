using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	int power = 3;
	bool grounded = true;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(grounded){
			if(Input.GetKey(KeyCode.W)){this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.forward*power;}
			if(Input.GetKey(KeyCode.S)){this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.back*power;}
			if(Input.GetKey(KeyCode.A)){this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.left*power;}
			if(Input.GetKey(KeyCode.D)){this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.right*power;}
			if(Input.GetKey(KeyCode.Space)){this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.up*power;}
		}
	} // END UPDATE

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Ground"){grounded = true;}
	}

	void OnCollisionExit(Collision col) {
		if(col.gameObject.tag == "Ground"){grounded = false;}
	}

} // END CLASS MOVEMENT