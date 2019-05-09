using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyButton : MonoBehaviour {

	public Button copy;

	Button thisBtn;

	// Use this for initialization
	void Start () {
		thisBtn = GetComponent<Button>();

		thisBtn.onClick.AddListener( OtherClick);
	}
	
	// Update is called once per frame
	void Update () {
		thisBtn.interactable = copy.interactable;
	}

	void OtherClick(){
		copy.onClick.Invoke();
	}
}
