using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject mainScreen;

	// Use this for initialization
	void Start () {
        mainScreen.SetActive(true);
        Debug.Log("Tá ativando");
	}
}
