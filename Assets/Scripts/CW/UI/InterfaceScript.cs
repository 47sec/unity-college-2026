using UnityEngine;
using UnityEngine.UIElements;
public class InterfaceScript : MonoBehaviour{
	Label timer;
    private void Awake(){
        timer = GetComponent<UIDocument>().rootVisualElement.Q("Timer") as Label;
    }
    void Update(){
        timer.text = Mathf.FloorToInt(Time.fixedTime).ToString();
	}
}
