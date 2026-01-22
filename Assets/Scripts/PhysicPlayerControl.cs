using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicPlayerControl : MonoBehaviour
{
	public bool is_gravitated;
	InputAction move;
	Vector3 camera_size;
	float current_object_size_x, current_object_size_y;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		is_gravitated = false;
		move = InputSystem.actions.FindAction("Move");
		current_object_size_x = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		current_object_size_y = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector2 move_direction = move.ReadValue<Vector2>();
		GetComponent<Rigidbody2D>().linearVelocity = move_direction*3;
		if (InputSystem.actions.FindAction("Jump").IsPressed())
		{
			switch (GetComponent<Rigidbody2D>().gravityScale){
				case 0: GetComponent<Rigidbody2D>().gravityScale = 10;break;
				case 10: GetComponent<Rigidbody2D>().gravityScale = 0;break;
			}
		}
	}
}
