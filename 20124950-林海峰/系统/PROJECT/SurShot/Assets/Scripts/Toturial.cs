using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Toturial : MonoBehaviour {
//	public EnemyHealth enemyHealth;
	public 	GameObject Bunny;
	// Use this for initialization
	void Start () {
		Bunny = GameObject.Find ("ZomBunny");
//		Bunny.activeSelf = enabled;
		//Debug.Log ("Get");
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (enemyHealth.currentHealth);
		if (Bunny == null) {

			//Debug.Log ("不存在");
			SceneManager.LoadScene (1);
		} else {
			//Debug.Log ("存在");

		}

	}
}
