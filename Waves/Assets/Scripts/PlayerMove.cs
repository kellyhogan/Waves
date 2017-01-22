using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


	public Rigidbody2D rb2d;
	public float moveForce;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveLeft(){
		rb2d.AddForce(new Vector2 ((-1*moveForce), 0));
	}
	public void moveRight(){
		rb2d.AddForce(new Vector2 (moveForce, 0));
	}
	public void moveUp(){
		rb2d.AddForce(new Vector2 (0, moveForce));
	}
	public void moveDown(){
		rb2d.AddForce(new Vector2 (0, (-1*moveForce)));
	}
}
