using UnityEngine;
using System.Collections;

public class Spy_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool spy_spawn;
	public static float Speed = 1.07f;
	public static float Jump = 2.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();

	Ray2D ray;
	RaycastHit2D hit;

	public GameObject gunPoint;
	public GameObject bullet;

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
			Shooting ();
		}
	}

	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Spy_Feet").transform.position, Vector2.down);

		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shooting(){
		GameObject spyBullet = Instantiate (bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
		spyBullet.tag = "Bullet";
		Destroy (spyBullet, 0.8f);
		if(Movement.facingRight){
			spyBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
		}
		if(!Movement.facingRight){
			spyBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 200);
		}
	}
}

