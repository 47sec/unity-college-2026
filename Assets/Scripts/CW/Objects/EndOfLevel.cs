using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndOfLevel : MonoBehaviour{
	UIDocument interface_document;
	Button continue_button;
	Label win_text;
    Button important_button;

    private void Awake(){
        important_button = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>().rootVisualElement.Q("continueButton") as Button;

        interface_document = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>();
		continue_button = interface_document.rootVisualElement.Q("continueButton") as Button;
		win_text = interface_document.rootVisualElement.Q("WinText") as Label;
		continue_button.SetEnabled(false);
		continue_button.visible = false;
	}
	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Player"){
            important_button.SetEnabled(true);
            important_button.visible = true;
            important_button.RegisterCallback<ClickEvent>(youWin);
            Time.timeScale = 0;
			win_text.text = "YOU WIN";
			continue_button.visible = true;
			continue_button.SetEnabled(true);
		}
	}
    void youWin(ClickEvent ev)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
