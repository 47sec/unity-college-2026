using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
	public float speed_multipliyer;
	InputAction move;
	Vector3 camera_size;
	string str;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		camera_size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		move = InputSystem.actions.FindAction("Move");
		str = "Hello, World!";
		Debug.Log(str);
		Debug.Log(gameObject.name);
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 current_position = transform.position;
        Vector2 move_direction = move.ReadValue<Vector2>();
		if (Keyboard.current.spaceKey.wasPressedThisFrame) Debug.Log("Jump");
		transform.Translate(move_direction / speed_multipliyer);
		current_position.x = Mathf.Clamp(transform.position.x, -camera_size.x, camera_size.x);
		current_position.y = Mathf.Clamp(transform.position.y, -camera_size.y, camera_size.y);
	}
}
