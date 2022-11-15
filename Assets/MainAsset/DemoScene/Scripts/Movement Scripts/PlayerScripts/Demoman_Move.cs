using UnityEngine;
using System.Collections;

public class Demoman_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool demoman_spawn;
	public static float Speed = 0.9f;
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
	public float bulletStrength;

	void Start () {
		bulletStrength = 200;
		anim = GetComponent<Animator>();
	}
	void FixedUpdate(){
		GroundDetection ();
	}

	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(rigid.velocity.x));
		anim.SetBool ("touchingGround", grounded);

		Move.Motion(Speed, Jump, rigid, grounded, Scout, sprite);

		if(Input.GetKey(shootKey)){
			bulletStrength = bulletStrength + (Time.deltaTime * 200);
		}
		if(Input.GetKeyUp(shootKey)){
			Shooting ();

		}
	}


	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Demoman_Feet").transform.position, Vector2.down);
		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shooting(){
		if(bulletStrength > 600){
			bulletStrength = 600;
		}
		GameObject DemomanBullet = Instantiate (bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
		DemomanBullet.tag = "Bullet";
		DemomanBullet.GetComponent<Transform> ().eulerAngles = new Vector3 (0,0, Random.Range(0,360));
		if(Movement.facingRight){
			DemomanBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * bulletStrength);
		}
		if(!Movement.facingRight){
			DemomanBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * bulletStrength);
		}
		bulletStrength = 200;
	}
}


