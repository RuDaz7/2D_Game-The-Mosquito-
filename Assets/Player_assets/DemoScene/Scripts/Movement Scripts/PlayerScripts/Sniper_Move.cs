using UnityEngine;
using System.Collections;

public class Sniper_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool sniper_spawn;
	public static float Speed = 1.00f;
	public static float Jump = 2.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();

	Ray2D ray;
	RaycastHit2D hit;

	public GameObject bullet;
	public GameObject bulletSpawn;
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
		hit = Physics2D.Raycast (GameObject.Find("Sniper_Feet").transform.position, Vector2.down);

		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shoot(){
		GameObject SniperBullet = Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
		SniperBullet.tag = "Bullet";
		if(Movement.facingRight){
			SniperBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 550);
		}
		if(!Movement.facingRight){
			SniperBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 550);
		}
		Destroy (SniperBullet, 1.5f);
	}
}
