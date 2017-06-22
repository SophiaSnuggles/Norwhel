using UnityEngine;
using System.Collections;

public class movement2 : MonoBehaviour {
    Rigidbody rBody = null;
	Vector3 moveVector;
	public GameObject ReferencePoint;
	public Camera camera;

    public int speed = 3;
    public int jumpPower = 3;
    bool grounded = true;

    // START:
    void Start () {
        rBody = GetComponent<Rigidbody>();
	} // END START


	// UPDATE:
	void Update () {
        //if (grounded) {
            //moveVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Jump") * jumpPower, Input.GetAxisRaw("Vertical") * speed);
			moveVector = camera.transform.TransformVector(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Jump") * jumpPower, Input.GetAxisRaw("Vertical") * speed);
            rBody.MovePosition(rBody.position + moveVector * Time.deltaTime);
			//this.transform.forward = camera.transform.forward;

            if (Input.GetAxis("Jump") != 0.0f) { grounded = false; }
        //}
    } // END UPDATE


    // ON COLLISION ENTER:
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") { grounded = true; }
    }

    // ON COLLISION EXIT:
    //void OnCollisionExit(Collision col) {
        //if (col.gameObject.tag == "Ground") { grounded = false; }
    //}
}