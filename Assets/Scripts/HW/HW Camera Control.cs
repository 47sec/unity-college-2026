using Unity.VisualScripting;
using UnityEngine;

public class HWCameraControl : MonoBehaviour
{
    [SerializeField] GameObject followed_object;
	[SerializeField] float dead_zone = 4, speed = 10f;
	void Start()
	{
		followed_object = GameObject.FindGameObjectWithTag("Player");
	}
	void Update()
	{
		//if(
		//	Mathf.Abs(followed_object.transform.position.x - transform.position.x) > dead_zone
		//	||
		//	Mathf.Abs(followed_object.transform.position.y - transform.position.y) > dead_zone
		//	)
		//{
		//	transform.position = followed_object.transform.position + new Vector3(0,0,-10);
		//}
		if(Vector3.Distance(followed_object.transform.position,transform.position) > dead_zone){
			transform.position = Vector3.MoveTowards(transform.position,
				followed_object.transform.position + new Vector3(0,0,-10)
				, speed * Time.deltaTime);
			//transform.position = followed_object.transform.position + new Vector3(0,0,-10);
		}
	}
}
