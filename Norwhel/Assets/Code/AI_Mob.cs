﻿using UnityEngine;
using System.Collections;

public class AI_Mob : MonoBehaviour {
    // AI VARIABLES:
    public int HP = 10;
    public float MoveSpeed = 0.5f;
    public float ChaseDistance = 3.0f;
    public float AttackDistance = 1.0f;
    public float waitTime = 0.5f;
    private float DistanceToPlayer;
    private Vector3 POS;
	private Vector3 SpawnPoint = new Vector3(0, 0, 0);
	private Quaternion upright = new Quaternion(0, 0, 0, 0);
    //Animator anim;

    private SpriteRenderer spriteRend;
    private GameObject Player;
    public GameObject projectile;

    public AudioClip hitClip;
    AudioSource hitSource;

    // START:
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        //anim = GetComponent<Animator>();
        SpawnPoint = transform.position;
        //spriteRend = GetComponent<SpriteRenderer>();
        hitSource = GetComponent<AudioSource>();
    } // END START()

    // UPDATE:
    void Update() {
		if (this.transform.rotation != upright) {
			transform.rotation = Quaternion.Slerp(this.transform.rotation, upright, Time.time * 1);
		}

        DistanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        POS = new Vector3(transform.position.x, transform.position.y);

        if (HP <= 0) {
            Destroy(this.gameObject);
        }

        if (POS == SpawnPoint) {
            //anim.SetBool("isWalking", false);
        }

        //  If the distance between the mob and the player
        //  is less than or equal to the ChaseDistance,
        //  and greater than the AttackDistance,
        //  the mob moves towards the player.
        if (DistanceToPlayer <= ChaseDistance && DistanceToPlayer > AttackDistance) {
            //anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, SpawnPoint, MoveSpeed * Time.deltaTime);
        }

        //  If the distance between the mob and the player
        //  is less than or equal to the AttackDistance,
        //  the mob launches a projectile at the player.
        if (DistanceToPlayer <= AttackDistance) {
            //Debug.Log(this.gameObject.name + " is now in range! Ready to shoot player!");
            //anim.SetBool("isWalking", true);
            transform.position = transform.position;

            waitTime -= Time.deltaTime;
            if (waitTime <= 0) {
                Instantiate(projectile, transform.position, Quaternion.identity);
                waitTime = 0.5f;
            }
        }
    } // END UPDATE()

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Sword") {
            Debug.Log(HP);
            //spriteRend.color = new Color(1f, 0f, 0f, 1f);
            HP--;
            hitSource.Play();
        } 
    }

    void OnTriggerExit() {
        //spriteRend.color = new Color(1f, 1f, 1f, 1f);
    }
} // END CLASS AI_Mob