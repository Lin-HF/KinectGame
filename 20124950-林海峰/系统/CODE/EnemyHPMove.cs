using UnityEngine;
using System.Collections;

public class EnemyHPMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Camera.main.transform.rotation;
	}
}
