using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

	public QuestionLoader questioLoad;

	public bool certo = false;
	Button disButton;
    public Button endButton;

	public Image rightAnswerButt;

	Color corRight = new Color32(0xA0, 0xED,0xE3,0xFF);
	Color corWrong = new Color32(0xEF,0xC5,0xC5,0xFF);

	// Use this for initialization
	void Start () {
		disButton = GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Certo(){certo = true;} // marca esse como certo

	public void Clicou(){
		GameManager.gabarito += "Respondido: " + GetComponentInChildren<Text>().text + "\n\n";
		questioLoad.AddRespostaCerta();

        endButton.Select();

        if (certo)
			Acertou();
		else
			Errou();
    }

	public void Acertou(){
		GetComponent<Image>().color = corRight;

		questioLoad.acertou.Invoke();

		GlobalVars.nota ++;
        
		/*/
		ColorBlock cb = disButton.colors;
        cb.normalColor = Color.green;
        disButton.colors = cb;*/
		//disButton.col
	}

	public void Errou(){
		GetComponent<Image>().color = corWrong;

		questioLoad.errou.Invoke();

		rightAnswerButt.color = corRight;
		/* 
		ColorBlock cb = disButton.colors;
        cb.normalColor = Color.red;
        disButton.colors = cb;*/
		//disButton.col
	}

	public void DoReset(){
		GetComponent<Image>().color = Color.white;
	}
}
