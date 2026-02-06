using UnityEngine;
public class UpDownPlatform : MonoBehaviour{
	public float min_y, max_y, speed, deflection;
	public bool is_going_down;
	Vector3 start_position;
	void Start(){
		start_position = transform.position;
		min_y = -2;
		max_y = 2;
		speed = 0.01f;
	}
	void FixedUpdate(){
		deflection = transform.position.y - start_position.y;
		if (deflection >= max_y)
			is_going_down = true;
		if (deflection <= min_y)
			is_going_down = false;
		if (is_going_down) transform.Translate(new Vector3(0, -speed, 0));
		if (!is_going_down) transform.Translate(new Vector3(0, speed, 0));
		Debug.Log(is_going_down);
	}
}
