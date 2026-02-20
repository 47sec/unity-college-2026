using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class InterfaceScript : MonoBehaviour{
	Label timer;
    Button next_level;
    private void Awake(){
        timer = GetComponent<UIDocument>().rootVisualElement.Q("Timer") as Label;
        next_level = GetComponent<UIDocument>().rootVisualElement.Q("continueButton") as Button;
        next_level.RegisterCallback<ClickEvent>(nextLevel);
    }
    void Update(){  
        timer.text = Mathf.FloorToInt(Time.fixedTime).ToString();
	}
    private void OnDisable()
    {
        next_level.UnregisterCallback<ClickEvent>(nextLevel);
        next_level.UnregisterCallback<ClickEvent>(restartLevel);
    }
    void nextLevel(ClickEvent evt)
    {
        //Debug.Log("Button is pressed");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//”казываете пор€дковый номер из списка сцен
    }
    void restartLevel(ClickEvent evt){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
