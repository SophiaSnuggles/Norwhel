using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour {
	public Texture2D windowTexture;
	private Vector2 position = new Vector2(400, 600);
	private Vector2 size = new Vector2(800, 200);
	public float margin = 5;
	private bool displayDialogue = false;
	private bool inRange = false;
	public string text;
	public GUIStyle TextGUI = new GUIStyle();
	private Quaternion upright = new Quaternion(0, 0, 0, 0);

	// START:
	void Start () {	}


	// UPDATE:
	void Update () {
		if (this.transform.rotation != upright) {
			transform.rotation = Quaternion.Slerp(this.transform.rotation, upright, Time.time * 1);
		}

		if (inRange) {
			if (Input.GetButtonDown ("Fire1")) {
				displayDialogue = true;
			}
		} else
			displayDialogue = false;
	} // END Update


	// ON GUI:
	void OnGUI() {
		GUILayout.BeginArea (new Rect (position.x, position.y, size.x, size.y));

			if (displayDialogue) {
				GUI.DrawTexture (new Rect (0, 0, size.x, size.y), windowTexture, ScaleMode.StretchToFill, true, 1);

				GUILayout.BeginArea (new Rect (margin, margin, size.x - (margin * 2), size.y - (margin * 2)));
					GUILayout.Label (text, TextGUI);
				GUILayout.EndArea();
			}
		GUILayout.EndArea();
	} // END OnGUI


	// ON TRIGGER ENTER:
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			inRange = true;
		}
	} // END OnTriggerEnter


	// ON TRIGGER EXIT:
	void OnTriggerExit() {
		inRange = false;
	} // END OnTriggerExit


} // END class questnpc