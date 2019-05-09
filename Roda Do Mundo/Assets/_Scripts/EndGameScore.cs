using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour {

	public Text txtScore;

	public Text txtFeedback;
	public Transform[] objFeedback;

	//public string[] titleMessages;

	public string[] feedMessages;

	public int[] scores;

	public Transform[] stars;

	public Transform[] noStars;

	int goodLevel = 0;
	
	//public InputField inputField;

	public Text testText;

	// Use this for initialization
	public void MyStart () {
		//atualiza texto score
		txtScore.text = (GameManager.score + " pontos");
		DoGoodLevel();
		ChangeGood();

		txtFeedback.text = feedMessages[goodLevel];

		//inputField.text = GameManager.gabarito;
		testText.text = GameManager.gabarito;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void DoGoodLevel(){
		if( GameManager.score < scores[1])
			goodLevel = 0;
		else if(GameManager.score < scores[2])
			goodLevel = 1;
		else if(GameManager.score < scores[3])
			goodLevel = 2;
		else if(GameManager.score >= scores[3])
			goodLevel = 3;

	}


	void ChangeGood(){
		print(goodLevel);
		for(int i = 0; i<goodLevel; i++){
			stars[i].gameObject.SetActive(true);
			noStars[i].gameObject.SetActive(false);
		}


	}

	public void ResetScore(){
		GameManager.score =0;
	}


}
