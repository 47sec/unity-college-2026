using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.UI;
using UnityEngine.UIElements;
public class Interface : MonoBehaviour
{
    UIDocument user_interface;
    Label time;
    Button next_level;
    private void Awake()
    {
        user_interface = GetComponent<UIDocument>();
        time =  user_interface.rootVisualElement.Q("TimeText") as Label;
        next_level = user_interface.rootVisualElement.Q("Continue") as Button;
        next_level.RegisterCallback<ClickEvent>(nextLevelClick);
    }
    private void OnDisable()
    {
        next_level.UnregisterCallback<ClickEvent>(nextLevelClick);
    }
    private void nextLevelClick(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        time.text = Mathf.FloorToInt(Time.fixedTime).ToString();
    }
}
