using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	Transform player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;


	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {

			nav.SetDestination (player.position);  //设置怪物自动导航的目标
		} else {
			nav.enabled = false;
		}
	}
}
