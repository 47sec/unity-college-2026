using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelComplete : MonoBehaviour
{
    UIDocument user_interface;
    Label win;
    Button next_level;
    private void Awake()
    {
        user_interface = GameObject.FindGameObjectWithTag("UserInterface").GetComponent<UIDocument>();
        win = user_interface.rootVisualElement.Q("WinText") as Label;
        next_level = user_interface.rootVisualElement.Q("Continue") as Button;
        next_level.visible = false;
        next_level.SetEnabled(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            win.text = "YouWin";
            next_level.SetEnabled(true);
            next_level.visible = true;
        }
    }
}
