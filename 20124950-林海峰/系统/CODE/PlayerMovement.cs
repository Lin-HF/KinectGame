using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 6f;

	Vector3 movement;
	float move = 1;
	Rigidbody playerRididbody;
	Animator anim;
//	int floorMask;
	float camRayLength = 100f;


	Vector3 vector;
 	GameObject LeftHand;
	GameObject RightHand;
	GameObject head;
	GameObject neck;
	public float FB;
	public float RL;

	void Awake(){

//		floorMask = LayerMask.GetMask ("Floor");

		playerRididbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();


	}
	
//	void FixedUpdate(){
	void Update(){
//		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw ("Vertical");
//		Move (h, v);
		LeftHand = GameObject.Find ("HandLeft");
		RightHand = GameObject.Find ("HandRight");

		Turning ();
		head = GameObject.Find ("Head");
		neck = GameObject.Find ("Neck");

		FB = (head.transform.position.z - neck.transform.position.z + 0.5f)*0.3f;
		RL = (head.transform.position.x - neck.transform.position.x);

//		transform.parent = head.transform;
//		transform.position = new Vector3 (head.transform.position.x , 18.6f , head.transform.position.z);

		Move (FB, RL);


		Animating (FB, RL);
	}
	void Move(float FB, float RL){

		movement.Set (FB, 0f, RL);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRididbody.MovePosition (transform.position + movement); 






//		if (FB > 1) {
//			playerRididbody.MovePosition (transform.position.z + move);
//		}
//		if (FB < -1) {
//			playerRididbody.MovePosition (transform.position.z - move);
//		}
//		if (RL > 1) {
//			playerRididbody.MovePosition (transform.position.x + move);
//		}
//		if (RL < -1) {
//			playerRididbody.MovePosition (transform.position.x - move);
//		}
	}

//	void Move(float h,float v){
//		movement.Set (h, 0f, v);  //设置movement的值
//		movement = movement.normalized * speed * Time.deltaTime;
//
//		playerRididbody.MovePosition (transform.position + movement);     //通过MovePosition()方法让主角移动
//	}
//
	void Animating(float h ,float v){
		bool walking = h != 0f || v != 0f;  //判断当前的角色是否在移动
		anim.SetBool ("IsWalking", walking);
	}

	void Turning(){
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);  //根据当前鼠标的位置，从摄像机发射一条射线，返回射线
//		RaycastHit floorHit;
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
//			Vector3 playerToMouse = floorHit.point - transform.position;
//			playerToMouse.y = 0f;
//			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//			playerRididbody.MoveRotation (newRotation);   


		vector = (LeftHand.transform.position - RightHand.transform.position).normalized;
		vector.y = 0;
		vector.z = -vector.z;

		Quaternion currentRotation = this.transform.rotation;
		Quaternion targetRotation = Quaternion.LookRotation (vector);
		transform.rotation = Quaternion.RotateTowards (currentRotation, targetRotation, 45);


	}
}
