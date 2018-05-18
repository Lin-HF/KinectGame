using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f;  //攻击时间时隔
	public int attackDamage = 10;  //攻击伤害值

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;  //是否在攻击范围内
	float timer; //计时器


	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		enemyHealth = gameObject.GetComponent<EnemyHealth> ();
		anim = GetComponent<Animator> ();
	}


	void OnTriggerEnter(Collider other){
		//如果触发了触发器的是主角，这样的话就设置playerInRange为真
		if (other.gameObject == player) { 
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}



	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;  //计时器开始计时
		if (playerInRange && timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0) {
			Attack();
		}

		//如果角色死亡，怪物就切换到空闲动画
		if (playerHealth.currentHealth <= 0) {
			anim.SetTrigger ("PlayerDead");  //播放怪物空闲动画
		}
	}

	//怪物攻击函数
	void Attack(){
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
