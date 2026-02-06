using UnityEngine;
public class CWJumpTrigger : MonoBehaviour{
    GameObject player;
	void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update(){}
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground")
        player.GetComponent<CWPlayerControl>().is_grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground")
        player.GetComponent<CWPlayerControl>().is_grounded = false;
    }
}
