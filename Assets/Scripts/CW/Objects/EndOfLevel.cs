using UnityEngine;
using UnityEngine.UIElements;

public class EndOfLevel : MonoBehaviour{
	UIDocument interface_document;
	Button continue_button;
	Label win_text;
    private void Awake(){
		interface_document = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>();
		continue_button = interface_document.rootVisualElement.Q("continueButton") as Button;
		win_text = interface_document.rootVisualElement.Q("WinText") as Label;
		continue_button.SetEnabled(false);
		continue_button.visible = false;
	}
	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Player"){
			Time.timeScale = 0;
			win_text.text = "YOU WIN";
			continue_button.visible = true;
			continue_button.SetEnabled(true);
		}
	}
}
