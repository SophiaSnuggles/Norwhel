﻿using UnityEngine;
using System.Collections;

public class AI_Projectile : MonoBehaviour {
    public int MoveSpeed = 4;
    private GameObject Player;

    // START:
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 3);
    } // END START
	
	// UPDATE:
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
    } // END UPDATE

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
            Destroy(gameObject);
    }
} // END CLASS AI_Projectile