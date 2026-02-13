using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public GameObject target;
	public float dead_zone, speed;
	private void Awake(){
		target = GameObject.FindGameObjectWithTag("Player");
	}
	void Update(){
		if (Vector2.Distance(transform.position, target.transform.position) > dead_zone){
			transform.position =  Vector3.MoveTowards(
				transform.position,
				target.transform.position + new Vector3(0, 0, -10),
				speed * Time.deltaTime
				);
		}
	}
}
