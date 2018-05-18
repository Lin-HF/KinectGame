using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;

	public Slider hpUI;

	Animator anim;
	AudioSource enemyAudio;
	public ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;

	bool isDead;
	bool isSinking;


	void Awake(){
		anim = GetComponent<Animator> ();
		enemyAudio = GetComponent<AudioSource> ();
		hitParticles = GetComponentInChildren<ParticleSystem> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();
		hpUI = GetComponentInChildren<Slider> ();
		currentHealth = startingHealth;
		hpUI.value = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
//		if (currentHealth <= 0)
//			Death ();
//		
		if (isSinking) {
			StartSinking ();
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}

		hpUI.value = currentHealth;
	}


	public void TakeDamage(int amount,Vector3 hitPoint){
		if (isDead) 
			return;
		enemyAudio.Play ();

		currentHealth -= amount;  //怪物受到攻击，减少生命值
		hitParticles.transform.position = hitPoint;
		hitParticles.Play ();
		if (currentHealth <= 0) {
			ScoreManager.score += scoreValue;
			Death();
		}

	}

	void Death(){
		isDead = true;

		capsuleCollider.isTrigger = true;  //变成触发器，不会挡住子弹的光线
		enemyAudio.clip = deathClip;
		anim.SetTrigger ("Dead"); //播放死亡动画


		enemyAudio.Play();
		StartSinking ();

	}

	public void StartSinking(){
		GetComponent<NavMeshAgent> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		isSinking = true;
//		transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);

		Destroy(gameObject,2f);
	}
}
