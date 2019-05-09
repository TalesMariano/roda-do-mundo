using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

	public static int score= 100;
	static int casasAndar;

	public static string gabarito;

	public static int lastNumber = -1;

    public Button bonusButton;

	[Header("Construções")]
	public GameObject constructSelect;




	[Header("Progressao do jogo")]
	public Slider sliderProgression;
	int sliderMaxValue = 7;

	[Header("End Game")]
	public UnityEvent endGame;



	public Carta[] cartas;

	public Carta cartaBonus;
	public QuestionLoader cartBonus;


	public static void ParouRoleta(){
		if(GameManager.lastNumber != 6)
			GameControl.MovePlayer(1);
	}


	public void RespondeuPergunta(int pontos){
		score += pontos;
		//update ui
		//



	}

	 public void PerguntaBonus(){
		StartCoroutine(Stuff(1));

	}

	 IEnumerator Stuff(float duration){
        //AtualizaCartas();
        yield return new WaitForSeconds(duration);
        cartaBonus.Show();//landinSpace.Invoke();
        bonusButton.Select();
        Debug.Log("Chamou carta bônus");

    }


	[ContextMenu("Mostra Cartas")]
	public void MostraCartas(){
		foreach(Carta c in cartas){
			c.Show();
		}
	}

	public void MostraBonus(){
		cartaBonus.Show();
    }



	[ContextMenu("Hide Cartas")]
	public void HideCartas(){
		foreach(Carta c in cartas){
			c.Hide();
		}
	}

	public void AddScore(int add){
		score += add;

	}

	/* //old stuff
	[Header("Perguntas")]
	public GameObject uiPerguntas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		//End Game
		if(sliderProgression.value >=sliderMaxValue){
			endGame.Invoke();
		}

	}

	public void SelectConstruction(GameObject construcao){
		constructSelect = construcao;
	}

	public void MoveSliderUp(){
		sliderProgression.value = sliderProgression.value +1;
		
	}

	public void NoSelect(){
		constructSelect = null;
		GlobalVars.gRot = 0;
	}*/
}
