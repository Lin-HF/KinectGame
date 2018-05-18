using UnityEngine;
using System.Collections;

public class HandControlTest : MonoBehaviour {

	GameObject Right_hand;
	GameObject Left_hand;
	GameObject ChoseHand;
	public GameObject controlHand;
	//	GameObject hand;
	GameObject text;
	float timer;
	//Better Hover
	Vector3 offset;

	// Use this for initialization
	void Start () {
//		text = GameObject.Find("loading");

	}

	// Update is called once per frame
	void Update () {
		Right_hand = GameObject.Find ("HandRight");
		Left_hand = GameObject.Find ("HandLeft");

		if (Right_hand.transform.position.y - Left_hand.transform.position.y >= 0) {
			ChoseHand = Right_hand;
			Debug.Log ("Right Hand");
		} else {
			ChoseHand = Left_hand;
			Debug.Log ("Left Hand");
		}


	
			Debug.Log ("Start");
			offset = transform.position - ChoseHand.transform.position;
			Debug.Log ("offset" + offset);
			Vector3 targetCamPos = ChoseHand.transform.position + offset;  //保持摄像机与目标的相对偏移
			Debug.Log("Target = " + targetCamPos);
			transform.position = Vector3.Lerp (transform.position, targetCamPos, 1f * Time.deltaTime);  
			Debug.Log ("Strat Move");
			
			
	}
}
