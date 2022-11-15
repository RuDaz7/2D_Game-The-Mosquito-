using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour{
	public bool canDoubleJump = false;
	public static bool facingRight;

	public KeyCode jumpKey = KeyCode.W;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public static float timer = 5.0f;
	public void Motion (float speed, float jump, Rigidbody2D rdbdy, bool grounded, bool isScout, Transform sprite){
		/*if(spyBullet.freezePlayer){
			speed = speed / 2;
			jump = jump / 2;
			if(timer > 0){
				print ("TImer COunting Down");
				timer = timer - Time.deltaTime;
			}
			if(timer < 0){
				print ("Done");
				spyBullet.freezePlayerD = false;
			}
		}*/

		if (Input.GetKeyDown (jumpKey)) {
			if(grounded){
			rdbdy.velocity = new Vector2 ( rdbdy.velocity.x, jump);
			}

			if (grounded && isScout) {
				rdbdy.velocity = new Vector2 (rdbdy.velocity.x, jump);
				canDoubleJump = true;
			} else {
				if(canDoubleJump){
					canDoubleJump = false;
					rdbdy.velocity = new Vector2 (rdbdy.velocity.x, (jump - 1));
				}
			
			}
		}

		if (Input.GetKey (leftKey)) {
			if(sprite.localScale.x > 1){
				sprite.localScale = new Vector3 (sprite.localScale.x * -1, sprite.localScale.y, sprite.localScale.z);
			}
			facingRight = false;
			rdbdy.velocity = new Vector2 (-speed,  rdbdy.velocity.y);
		}
		if (Input.GetKey (rightKey)) {
			if(sprite.localScale.x < 1){
				sprite.localScale = new Vector3 (sprite.localScale.x * -1, sprite.localScale.y, sprite.localScale.z);
			}
			facingRight = true;
			rdbdy.velocity = new Vector2 (speed, rdbdy.velocity.y);
		}
	}


}