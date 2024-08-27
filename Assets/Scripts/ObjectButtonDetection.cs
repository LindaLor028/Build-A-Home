using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectButtonDetection : MonoBehaviour
{
    public Button yourButton;
    public ManipulateItem manipulate;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        manipulate.SetItem(this.gameObject);
	}
}

