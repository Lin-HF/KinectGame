using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100;  
	public int currentHealth;

	public AudioClip deathClip;
	PlayerMovement playerMovement;
	Animator anim;
	AudioSource playerAudio;
	PlayerShooting playerShooting;

	bool isDead;    //是否死亡
	bool damaged;   //是否受到伤害

	public Slider healthSlider;//生命值UI
	public Image damageImage;
	public float flashSpeed;
	public Color flashColour;
//	Color flash = new Color (0f, 0f, 0f, 0f);

	void Awake(){
		playerAudio = GetComponent<AudioSource> ();
		playerMovement = GetComponent<PlayerMovement> ();
		playerShooting = GetComponentInChildren<PlayerShooting> ();
		anim = GetComponent<Animator> ();

		currentHealth = startingHealth;  //把初始生命值置为当前生命值

	}

	void Start(){
		flashSpeed = 1f;
		flashColour = new Color (1f, 0f, 0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColour;
			damaged = false;
		}else{
		
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
	//		damageImage.color = Color.Lerp (damageImage.color, new Color(0f,0f,0f,0f), flashSpeed*Time.deltaTime);
//			damageImage.color = new Color(0f,0f,0f,0f);
	//		Debug.Log (flashSpeed);
		}
//
//				if (damaged) {
//					damageImage.color = flashColour;
//				damageImage.color = Color.Lerp (damageImage.color, flash, flashSpeed * Time.deltaTime);
//					damaged = false;
//				
//				
//					
//				}
	}

	public void TakeDamage(int amount){
		damaged = true;

		currentHealth -= amount;  //生命值减少
		healthSlider.value = currentHealth;
		playerAudio.Play ();
		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death(){
		isDead = true;

		playerMovement.enabled = false;  //禁用掉玩家的控制
		anim.SetTrigger ("Die");  //播放死亡动画
		playerShooting.enabled = false; 

		playerAudio.clip = deathClip;
		playerAudio.Play ();


		playerShooting.DisableEffects();





	}

	public void RestartLevel(){
		SceneManager.LoadScene (0);
	}

}
