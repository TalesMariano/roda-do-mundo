using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avaliacao : MonoBehaviour {

	public Image[] stars;

	public Text textAcertos;

	float notaNormalized;

	int nota5;

	public Text feedback;

	///public strings[] 

	// Use this for initialization
	void Start () {
		nota5 = NotaZero2Five();
 #if UNITY_EDITOR

	nota5= 5;

 #endif


		StartCoroutine(ChangeStars(nota5));

		ChangeText();

		Feedback();



	}
	
	void Feedback(){
		if(GlobalVars.nota>4)
			feedback.text = "Parabéns! Você demonstrar ter um conhecimento bom dos fundamentos de Geometria Espacial. Continue estudando e se aprofundando!";
	}

	// Update is called once per frame
	void Update () {
		
	}


	public void ChangeUINota(int nota5){



	}

	void ChangeText(){
		
		//print("mudou texto");

		textAcertos.text = (GlobalVars.nota + "/" + GlobalVars.maxNota + " Acertos!");

	}

	IEnumerator ChangeStars(int numStars){
		for(int i = 0; i<numStars; i++){
			yield return new WaitForSeconds(0.2f);
			stars[i].gameObject.SetActive(true);
			

		}

	}


	public int NotaZero2Five(){

		int nota = (int)((float)GlobalVars.nota / (float)GlobalVars.maxNota * 5);

		//print((int)((float)3 / (float)7 * 5));

		return nota;
	}
}
