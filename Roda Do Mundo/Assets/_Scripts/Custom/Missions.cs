using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Missions : MonoBehaviour {

	public Text buttonText;

	public Button buttonNext;

	public SelectAvatars selecAvatar;


	int numMissoes = 7;

	public int missaoAtual = 0;


	public string[] textoMissao;

	public bool[] missaoFeita;

	public int[] numAvatar; // avatar

	public UnityEvent[] eventInicioMissao;

	public UnityEvent[] eventFimMissao;




	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	/*	#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.P))
			EndMission();
		#endif*/
	}

	public void NextMission(){
		
		// test temp
		EndMission(missaoAtual);


	}

	
	public void EndMission(){
		missaoFeita[missaoAtual] = true;
		eventFimMissao[missaoAtual].Invoke();

		//teste next
		//missaoAtual++;
		
		buttonNext.interactable = true;
		

	}

	public void EndMission(int n){
		missaoFeita[n] = true;
		eventFimMissao[n].Invoke();

		//teste next
		//missaoAtual++;
		
		buttonNext.interactable = true;
		

	}

	public void StartNextMission(){

		eventInicioMissao[missaoAtual].Invoke();
		
		//teste next
		missaoAtual++;

		selecAvatar.Select(numAvatar[missaoAtual]);

		

		NextMissionText();
		


		
	}

	public void NextMissionText(){
		buttonText.text = textoMissao[missaoAtual];
	}
}
