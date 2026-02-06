using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour{
	Rigidbody2D rigid;
	public bool grounded;
	public float speed_multiplyer, jump_force, max_speed;
	InputAction move, jump;
	Vector3 move_direction;
	void Start(){
		speed_multiplyer = 10;
		jump_force = 125;
		move = InputSystem.actions.FindAction("Move");
		jump = InputSystem.actions.FindAction("Jump");
		rigid = GetComponent<Rigidbody2D>();
	}
	void Update(){
	}
	private void FixedUpdate(){
		move_direction = move.ReadValue<Vector2>();
		if (jump.IsPressed() && grounded)
		{
			rigid.AddForceY(jump_force);
		}
		if(rigid.linearVelocity.magnitude <= 5) rigid.AddForce(move_direction*speed_multiplyer);
	}
	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Ground") grounded = true;
	}
	private void OnCollisionExit2D(Collision2D collision){
		if(collision.gameObject.tag == "Ground") grounded = false;
	}
}
