﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	float speed;
	bool PP = true; // Player projectile too check if shot by enemy or player
	public PlayerMovement PM;
	public PlayerMovement2 PM2;
	public PlayerMovement3 PM3; 
	public PlayerMovement4 PM4;
	public PlayerManager PMan;
	int ProVal;
	int[] Lifes;
	Vector3 startPos;
	bool UporDown;

	// Use this for initialization
	void Start ()
	{	
		Lifes = new int[5];
		speed = 2f;
		PMan = GameObject.Find("Manager").GetComponent<PlayerManager>();
		Lifes = PMan.lifeCheck();
		bool[] pCheck = new bool[PMan.maxPCount];
		pCheck = PMan.playerCheck ();
		if(pCheck[0] == true && Lifes[0] < 3)
		PM = GameObject.Find("P1").GetComponent<PlayerMovement>();
		if(pCheck[1] == true && Lifes[1] < 3)
		PM2 = GameObject.Find("P2").GetComponent<PlayerMovement2>();
		if(pCheck[2] == true && Lifes[2] < 3)
		PM3 = GameObject.Find("P3").GetComponent<PlayerMovement3>();
		if(pCheck[3] == true && Lifes[3] < 3)
		PM4 = GameObject.Find("P4").GetComponent<PlayerMovement4>();
	}
	// Is a player projectile
	public void SetPPT()
	{
		PP = true;
	}
	//isnt a player projectile
	public void SetPPF()
	{
		PP = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "enemy") 
		{
		   if(PP == true)
			{
			 if(this.gameObject.name == "1")
			     PM.bulletDead ();
			 if(this.gameObject.name == "2")
				 PM2.bulletDead ();
			 if(this.gameObject.name == "3")
				 PM3.bulletDead ();
			 if(this.gameObject.name == "4")
				 PM4.bulletDead ();

			 Debug.Log("ENEMY HIT");
			 //Destroy(col.gameObject);
			 Destroy(this.gameObject);
			}
		}

		if (col.gameObject.tag == "Player") {
			string objName = col.gameObject.name;
			if(PP == false)
			 {
				if (objName == "P1") 
				{
					col.gameObject.GetComponent<PlayerMovement> ().enabled = !col.gameObject.GetComponent<PlayerMovement> ().enabled;
				}
				if (objName== "P2") 
				{
					col.gameObject.GetComponent<PlayerMovement> ().enabled = !col.gameObject.GetComponent<PlayerMovement> ().enabled;
				}
				if (objName== "P3") 
				{
					col.gameObject.GetComponent<PlayerMovement> ().enabled = !col.gameObject.GetComponent<PlayerMovement> ().enabled;
				}
				if (objName == "P4") 
				{
					col.gameObject.GetComponent<PlayerMovement> ().enabled = !col.gameObject.GetComponent<PlayerMovement> ().enabled;
				}

				col.gameObject.SetActive (false);
				PMan.playerDead (objName);
				Destroy (this.gameObject);
				Debug.Log ("PLAYER HIT BY ENEMY");
			}

			if (objName == "P1" && this.gameObject.name != "1") {
				col.gameObject.GetComponent<PlayerMovement> ().enabled = !col.gameObject.GetComponent<PlayerMovement> ().enabled;
				col.gameObject.SetActive (false);
				PMan.playerDead (objName);
				if (this.gameObject.name == "2")
					PM2.bulletDead ();
				if (this.gameObject.name == "3")
					PM3.bulletDead ();
				if (this.gameObject.name == "4")
					PM4.bulletDead ();
				Destroy (this.gameObject);
			}
			if (objName == "P2"  && this.gameObject.name != "2") {
				col.gameObject.GetComponent<PlayerMovement2> ().enabled = !col.gameObject.GetComponent<PlayerMovement2> ().enabled;
				col.gameObject.SetActive (false);
				PMan.playerDead (objName);
				if (this.gameObject.name == "1")
					PM.bulletDead ();
				if (this.gameObject.name == "3")
					PM3.bulletDead ();
				if (this.gameObject.name == "4")
					PM4.bulletDead ();
				Destroy (this.gameObject);
			}
			if (objName == "P3"  && this.gameObject.name != "3") {

				col.gameObject.GetComponent<PlayerMovement3> ().enabled = !col.gameObject.GetComponent<PlayerMovement3> ().enabled;
				col.gameObject.SetActive (false);
				PMan.playerDead (objName);
				if (this.gameObject.name == "1")
					PM.bulletDead ();
				if (this.gameObject.name == "2")
					PM3.bulletDead ();
				if (this.gameObject.name == "4")
					PM4.bulletDead ();
				Destroy (this.gameObject);
			}
			if (objName == "P4"  && this.gameObject.name != "4") 
			{

				col.gameObject.GetComponent<PlayerMovement4> ().enabled = !col.gameObject.GetComponent<PlayerMovement4> ().enabled;
				col.gameObject.SetActive (false);
				PMan.playerDead (objName);
				if (this.gameObject.name == "1")
					PM.bulletDead ();
				if (this.gameObject.name == "2")
					PM3.bulletDead ();
				if (this.gameObject.name == "3")
					PM4.bulletDead ();
				Destroy (this.gameObject);
			}
	
		//}
		}
	}


	// Update is called once per frame
	void Update ()
	{
	
		if (PP == true) 
		{

			Debug.Log ("I am player Bullet");
			Vector2 position = transform.position;
			if(this.name =="1" || this.name == "3")
			{
			position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
			}
			else
			{
				position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
			}
			transform.position = position;
		}
		if (PP == false) 
		{
			Debug.Log ("I am enemy bullet");
			Vector2 Eposition = transform.position;


			if(UporDown == false)
			{
			Eposition = new Vector2 (Eposition.x, Eposition.y - speed * Time.deltaTime);
			this.transform.position = Eposition;
			}
			else
			{
			 Eposition = new Vector2 (Eposition.x, Eposition.y + speed * Time.deltaTime);
			 this.transform.position = Eposition;
			}

		}
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Debug.Log ("Shots fired!");

		if (transform.position.y > max.y)
		{
			//if(ProMan!=null)
			if(this.gameObject.name == "1")
				PM.bulletDead ();
			if(this.gameObject.name == "2")
				PM2.bulletDead ();
			if(this.gameObject.name == "3")
				PM3.bulletDead ();
			if(this.gameObject.name == "4")
				PM4.bulletDead ();
			Destroy (this.gameObject);
			Debug.Log ("Bullet Despawned");
		
		}
		if (transform.position.y < min.y)
		{
			if(this.gameObject.name == "1")
				PM.bulletDead ();
			if(this.gameObject.name == "2")
				PM2.bulletDead ();
			if(this.gameObject.name == "3")
				PM3.bulletDead ();
			if(this.gameObject.name == "4")
				PM4.bulletDead ();
			Destroy (this.gameObject);
			Debug.Log ("Bullet Despawned");
		}
	}




}