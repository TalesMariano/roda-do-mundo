using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroScene : MonoBehaviour {
	public UnityEvent goEvent;


	// Use this for initialization
	void Start () {
		if(GameControl.gameOver)
			goEvent.Invoke();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
