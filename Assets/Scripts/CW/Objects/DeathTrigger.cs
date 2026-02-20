using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class DeathTrigger : MonoBehaviour{
    Label win_text;
    UIDocument interface_document;
    Button important_button;
    private void Awake()
    {
        important_button = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>().rootVisualElement.Q("continueButton") as Button;
        interface_document = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDocument>();
        win_text = interface_document.rootVisualElement.Q("WinText") as Label;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        important_button.SetEnabled(true);
        important_button.visible = true;
        important_button.RegisterCallback<ClickEvent>(youDied);
        if(collision.gameObject.tag == "Player"){
            Time.timeScale = 0;
            win_text.text = "YOU DIED";
        }
    }
    void youDied(ClickEvent ev)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}