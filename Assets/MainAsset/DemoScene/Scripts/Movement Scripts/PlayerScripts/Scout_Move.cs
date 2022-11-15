using UnityEngine;
using System.Collections;

public class Scout_Move : MonoBehaviour{
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool scout_spawn;
	public static float Speed = 1.33f;
	public static float Jump = 3f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = true;
	public Rigidbody2D rigid;

	public GameObject bullet;

	Movement Move = new Movement ();

	RaycastHit2D hit;

	public GameObject gunPointOne;
	public GameObject gunPointTwo;
	public GameObject gunPointThree;

	void Start () {
		anim = GetComponent<Animator>();
	}
	void FixedUpdate(){

		GroundDetection ();

		ground = grounded;
	}

	// Update is called once per frame
	void Update () {
		
		anim.SetFloat ("Speed", Mathf.Abs(rigid.velocity.x));
		anim.SetBool ("touchingGround", grounded);
		Move.Motion(Speed, Jump, rigid, grounded, Scout,sprite);
		if(Input.GetKeyDown(shootKey)){
			Shoot ();
		}
	}
		

	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Scout_Feet").transform.position, Vector2.down);
		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}

	}
	public void Shoot(){
		GameObject bulletTop = Instantiate (bullet, gunPointOne.transform.position, gunPointOne.transform.rotation) as GameObject;
		GameObject bulletMid = Instantiate (bullet, gunPointTwo.transform.position, gunPointTwo.transform.rotation) as GameObject;
		GameObject bulletBottom = Instantiate (bullet, gunPointThree.transform.position, gunPointThree.transform.rotation) as GameObject;
		bulletTop.tag = "Bullet";
		bulletMid.tag = "Bullet";
		bulletBottom.tag = "Bullet";
		Destroy (bulletTop, 0.30f);
		Destroy (bulletMid, 0.30f);
		Destroy (bulletBottom, 0.30f);

		if(Movement.facingRight){
			rigid.AddForce (-rigid.transform.right * 60);
			bulletTop.GetComponent<Rigidbody2D> ().AddForce (bulletTop.GetComponent<Rigidbody2D> ().transform.right * 125);
			bulletMid.GetComponent<Rigidbody2D> ().AddForce (bulletMid.GetComponent<Rigidbody2D> ().transform.right  * 125);
			bulletBottom.GetComponent<Rigidbody2D> ().AddForce (bulletBottom.GetComponent<Rigidbody2D> ().transform.right * 125);
		}
		if(!Movement.facingRight){
			rigid.AddForce (rigid.transform.right * 60);
			bulletTop.GetComponent<Rigidbody2D> ().AddForce (-bulletTop.GetComponent<Rigidbody2D> ().transform.right * 125);
			bulletMid.GetComponent<Rigidbody2D> ().AddForce (-bulletMid.GetComponent<Rigidbody2D> ().transform.right  * 125);
			bulletBottom.GetComponent<Rigidbody2D> ().AddForce (-bulletBottom.GetComponent<Rigidbody2D> ().transform.right * 125);
		}
}
}
