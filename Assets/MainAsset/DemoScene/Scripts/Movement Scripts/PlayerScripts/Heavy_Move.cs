using UnityEngine;
using System.Collections;

public class Heavy_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool heavy_spawn;
	public static float Speed = 0.8f;
	public static float Jump = 2.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();

	Ray2D ray;
	RaycastHit2D hit;

	public bool PressedDown;

	public GameObject bullet;
	public GameObject gunPoint;

	public float shotCounter;
	public float loadingCounter;

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

		Move.Motion(Speed, Jump, rigid, grounded, Scout, sprite);
		if(Input.GetKeyDown(shootKey)){
			PressedDown = true;
		}
		if(!Input.GetKey(shootKey)){
			PressedDown = false;
			shotCounter = 0.1f;
			loadingCounter = 2.5f;
		}
		if(PressedDown){
			loadingCounter = loadingCounter - Time.deltaTime;
			if(loadingCounter <= 0){
					shotCounter = shotCounter - Time.deltaTime;
					if(shotCounter <= 0){
					gunPoint.transform.eulerAngles = new Vector3(0,0,Random.Range(-15,15));
						GameObject heavyBullet = Instantiate (bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
						heavyBullet.tag = "Bullet";
						Destroy (heavyBullet, 0.5f);
						if(Movement.facingRight){
							heavyBullet.GetComponent<Rigidbody2D> ().AddForce (heavyBullet.GetComponent<Transform>().right * 200);
							}
						if(!Movement.facingRight){
							heavyBullet.GetComponent<Rigidbody2D> ().AddForce (-heavyBullet.GetComponent<Transform>().right * 200);
							}
						shotCounter = 0.05f;
						}

			}
		}
	}



	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Heavy_Feet").transform.position, Vector2.down);

		if(hit.distance == 0){
			grounded = true;
		}
		if(hit.distance != 0){
			grounded = false;
		}
	}

}


