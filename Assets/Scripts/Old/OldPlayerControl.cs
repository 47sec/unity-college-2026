using UnityEngine;
using UnityEngine.InputSystem;

public class OldPlayerControl : MonoBehaviour{
	InputAction move;
	Vector3 camera_size;
	float current_object_size_x, current_object_size_y;
	void Start(){
		camera_size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		move = InputSystem.actions.FindAction("Move");
		if (move != null) Debug.Log("Move is set");
		else Debug.Log("Move is not set");
		current_object_size_x = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
		current_object_size_y = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
	}
	void FixedUpdate(){
		Vector2 move_direction = move.ReadValue<Vector2>();
		Debug.Log(move_direction);
		//transform.Translate(move_direction);
		GetComponent<Rigidbody2D>().AddForce(move_direction/25);
	}
	void LateUpdate(){
		Vector3 current_position = transform.position;
		current_position.x = Mathf.Clamp(transform.position.x,-camera_size.x + current_object_size_x, camera_size.x-current_object_size_x);
		current_position.y = Mathf.Clamp(transform.position.y,-camera_size.y + current_object_size_y, camera_size.y-current_object_size_y);
		transform.position = current_position;
	}
}
