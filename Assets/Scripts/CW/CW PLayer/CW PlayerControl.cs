using UnityEngine;
using UnityEngine.InputSystem;
public class CWPlayerControl : MonoBehaviour{
	InputAction move, jump;
	Rigidbody2D rb;
	Vector2 move_direction;
	public float speed = 125f, max_speed = 5f, jump_force = 50;
	public bool is_grounded = false;
	void Start(){
		move = InputSystem.actions.FindAction("Move");
		jump = InputSystem.actions.FindAction("Jump");
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		move_direction = move.ReadValue<Vector2>();
		if (jump.IsPressed() && is_grounded) rb.AddForceY(jump_force);
		if(rb.linearVelocity.magnitude <= max_speed)
		rb.AddForceX(move_direction.x*speed);
	}
}
