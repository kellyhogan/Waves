using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


	public GameObject player;
	public float maxTime;
	public float minSwipeDist;

	float startTime;
	float endTime;
	float swipeDistance;
	float swipeTime;

	 Vector3 startPos;
	 Vector3 endPos;

	
	//public Vector2 startPos;
	//public Vector2 direction;
	//public bool directionChosen;
	void Update() {
		// Track a single touch as a direction control.
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			
			// Handle finger movements based on touch phase.
			switch (touch.phase) {
				// Record initial touch position.
				case TouchPhase.Began:
					startTime = Time.time;
					startPos = touch.position;
					//directionChosen = false;
					break;
				
				// Determine direction by comparing the current touch position with the initial one.
				//case TouchPhase.Moved:
					//direction = touch.position - startPos;
					//break;
				
				// Report that a direction has been chosen when the finger is lifted.
				case TouchPhase.Ended:
					//directionChosen = true;
					endTime = Time.time;
					endPos = touch.position;

					swipeDistance = (endPos - startPos).magnitude;
					swipeTime = endTime - startTime;

					if((swipeTime < maxTime) && (swipeDistance > minSwipeDist)){
						swipeObject();
					}
					break;
			}
		}
		//if (directionChosen) {
			// Something that uses the chosen direction...
		//}
	}

	void swipeObject(){

		Vector2 distance = endPos - startPos;

		if(Mathf.Abs (distance.x) > Mathf.Abs (distance.y)){
			if(distance.x > 0){
				Debug.Log("Right Horizontal Swipe");
				player.GetComponent<PlayerMove>().moveRight();
			}else{
				Debug.Log("Left Horizontal Swipe");
				player.GetComponent<PlayerMove>().moveLeft();
			}
		}else if(Mathf.Abs (distance.x) < Mathf.Abs (distance.y)){
			if(distance.y > 0){
				Debug.Log("Up Vertical Swipe");
				player.GetComponent<PlayerMove>().moveUp();
			}else{
				Debug.Log("Down Vertical Swipe");
				player.GetComponent<PlayerMove>().moveDown();
			}
		}

	}
}
