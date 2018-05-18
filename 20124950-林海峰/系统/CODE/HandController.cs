using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

public class HandController : MonoBehaviour {


//	GameObject Right_hand;
//	public GameObject controlHand;
//	GameObject hand;
//	GameObject text;
//	float timer;
//
//	// Use this for initialization
//	void Start () {
//		text = GameObject.Find("loading");
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		Right_hand = GameObject.Find ("HandRight");
//		if (Right_hand.activeInHierarchy) {
//
//			timer += Time.deltaTime;
//			if (timer > 2) {
//				Destroy(text,1f);
//				controlHand.transform.parent = Right_hand.transform;
//				controlHand.transform.position = new Vector3 (controlHand.transform.position.x, controlHand.transform.position.y, -10.75f);
//			}		
//		}
//	}

	GameObject Right_hand;
	GameObject Left_hand;
	GameObject ChoseHand;
	public GameObject controlHand;
//	GameObject hand;
	GameObject text;
	float timer;
	//Better Hover
//	Vector3 target;

	// Use this for initialization
	void Start () {
		text = GameObject.Find("loading");

	}

	// Update is called once per frame
	void Update () {
		Debug.DrawLine (controlHand.transform.position, Vector3.forward);
		Right_hand = GameObject.Find ("HandRight");
		Left_hand = GameObject.Find ("HandLeft");

		if (Right_hand.transform.position.y - Left_hand.transform.position.y >= 0) {
			ChoseHand = Right_hand;
		} else {
			ChoseHand = Left_hand;
		}

		timer += Time.deltaTime;
		if (ChoseHand.activeInHierarchy && timer > 3f) {


			if (ChoseHand.activeInHierarchy  && controlHand != null) {
				Destroy (text, 1f);
				controlHand.transform.parent = ChoseHand.transform;
				controlHand.transform.position =
					new Vector3 (controlHand.transform.position.x, controlHand.transform.position.y, -10.75f);

//				target = new Vector3 (controlHand.transform.position.x, controlHand.transform.position.y, 0);
//
//				controlHand.transform.position =  Vector3.Lerp (transform.position, target, 5 * Time.deltaTime); 

			} 
//			else {
//				controlHand = GameObject.Find ("hand2"); //新增代
//			}
		}
	}
}
