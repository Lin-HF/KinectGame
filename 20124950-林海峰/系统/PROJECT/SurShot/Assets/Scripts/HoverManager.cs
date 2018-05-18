using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HoverManager : MonoBehaviour {

	public float timer1;
	public float timer2;
	public float timer3;

	public GameObject hand;

	public GameObject startButton;
	public GameObject helpButton;
	public GameObject quitButton;

	public LayerMask startMask;
	public LayerMask helpMask;
	public LayerMask quitMask;

	bool choose;
	// Use this for initialization

	void Start () {
		choose = false;

//		if(GameObject.Find("HandLeft").transform.position.z
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray camRay = new Ray (hand.transform.position, Vector3.forward);
		RaycastHit UIhit;

		if (Physics.Raycast (camRay, out UIhit, 1000, startMask)) {
			startButton.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
			timer1 += Time.deltaTime;
		} else {
			startButton.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			timer1 = 0;
		}

		if (Physics.Raycast (camRay, out UIhit, 1000, helpMask)) {
			helpButton.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
			timer2 += Time.deltaTime;
		} else {
			helpButton.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			timer2 = 0;
		}

		if (Physics.Raycast (camRay, out UIhit, 1000, quitMask)) {
			quitButton.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
			timer3 += Time.deltaTime;
		} else {
			quitButton.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			timer3 = 0;
		}

		if (timer1 >= 1) {
	//		choose == true;
	//		Debug.Log ("Start");
			SceneManager.LoadScene (1);
		}
		if (timer2 >= 1) {
	//		Debug.Log ("Start");
			//		Debug.Log ("Start");
			SceneManager.LoadScene (2);
		}
		if (timer3 >= 1) {
//			#if UNITY_EDITOR
//			EditorApplication.isPlaying = false;
//			#else
			Application.Quit();
//			#endif
	//		Debug.Log ("Start");
		}
	}
}
