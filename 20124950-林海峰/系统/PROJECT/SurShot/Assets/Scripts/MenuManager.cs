using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {
	public GameObject rhand;
	public GameObject head;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rhand = GameObject.Find ("HnadRight");
		head = GameObject.Find ("Head");
		if (rhand.transform.position.y - head.transform.position.y > 0) {
			Pause ();
		}
	}

	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
}
