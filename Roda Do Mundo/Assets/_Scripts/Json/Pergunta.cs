using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pergunta : MonoBehaviour {

	public TextAsset json;

	public Sprite imagemQuestao;

	public Questao questao;

	public UnityEvent afterQuestion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ContextMenu("Load Json")]
	public void LoadJson(){

		questao = JsonUtility.FromJson<Questao>(json.text); //JsonHelper.getJsonArray<Dialogue>(json.text);

		transform.name = json.name;
	}

	public void Die(){
		Destroy(this);
	}
}
