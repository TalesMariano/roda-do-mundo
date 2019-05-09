using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcaMudaCor : MonoBehaviour {

	public SpriteRenderer sprite;
	public Color cor = Color.gray;

	// Use this for initialization
	void Start () {
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeColor(){
		sprite.color = cor;
	}

	void OnMouseDown()
	{
		
	}
}
