using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuestionLoader : MonoBehaviour {

	//public GameManager gm;

	public int dificuldade;

	public Pergunta pergunta;

	public ListaPerguntas lista;

	
	public Animator anim;

	public Text uiText;

	public Image uiImagem;
	public GameObject block;

	public Button[] uiMultiChoice;

	public UnityEvent acertou;
	public UnityEvent errou;

	public UnityEvent myAfterQuestion;



	// Use this for initialization
	void Start () {
		LoadQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ContextMenu("Load Question")]
	public void LoadQuestion(){
		pergunta.LoadJson();



		uiText.text = pergunta.questao.pergunta; // atualiza o texto da ui para a pergunta
		if(pergunta.imagemQuestao != null){//se nao tiver imagem, deixar vazio
			uiImagem.sprite = pergunta.imagemQuestao; // atualiza a imagem da ui para a imagem da questão
			uiImagem.SetNativeSize();
		}
		for(int i = 0; i < uiMultiChoice.Length; i++){ // para cada um dos botoes de resposta
			uiMultiChoice[i].GetComponentInChildren<Text>().text = pergunta.questao.respostas[i]; // atualiza a caixa de texto do botao para a pergunta
			if(i == pergunta.questao.numResposta)
				uiMultiChoice[i].GetComponent<AnswerButton>().certo = true;
			else 
				uiMultiChoice[i].GetComponent<AnswerButton>().certo = false;
				/*uiMultiChoice[i].onClick = acertou;
			//else	
				//uiMultiChoice[i].onClick = errou;*/
			uiMultiChoice[i].GetComponent<AnswerButton>().rightAnswerButt = uiMultiChoice[pergunta.questao.numResposta].GetComponent<Image>();
		}

	}

	public void LoadQuestion(Pergunta perg){
		//perg.LoadJson();

		pergunta = perg; // para  AddRespostaCerta() funcionar
		uiText.text = perg.questao.pergunta; // atualiza o texto da ui para a pergunta
		if(perg.imagemQuestao != null){//se nao tiver imagem, deixar vazio
			uiImagem.sprite = perg.imagemQuestao; // atualiza a imagem da ui para a imagem da questão
			uiImagem.SetNativeSize();
		}
		for(int i = 0; i < uiMultiChoice.Length; i++){ // para cada um dos botoes de resposta
			uiMultiChoice[i].GetComponentInChildren<Text>().text = perg.questao.respostas[i]; // atualiza a caixa de texto do botao para a pergunta
			if(i == perg.questao.numResposta)
				uiMultiChoice[i].GetComponent<AnswerButton>().certo = true;
			else 
				uiMultiChoice[i].GetComponent<AnswerButton>().certo = false;
				/*uiMultiChoice[i].onClick = acertou;
			//else	
				//uiMultiChoice[i].onClick = errou;*/
			uiMultiChoice[i].GetComponent<AnswerButton>().rightAnswerButt = uiMultiChoice[perg.questao.numResposta].GetComponent<Image>();
		}

		AddQuestionGabarito(perg);
	}


	public void ChamouCarta(){
		LoadQuestion(lista.PerguntaDificuldade(dificuldade));
	}


	public void ReceiveQuestion( Pergunta thePergunta){
		pergunta = thePergunta;
		anim.SetBool("Entrar", true);
		LoadQuestion();
	}

	public void Respondeu(){
		GetComponent<CanvasGroup>().blocksRaycasts = false;

		StartCoroutine(PosResposta());

		//gm.MoveSliderUp();

	}

	public void ResetCard(){



	}

	IEnumerator PosResposta(){

		anim.SetBool("Entrar", false);

		yield return new WaitForSeconds(3);

		

		for(int i = 0; i < uiMultiChoice.Length; i++){
			uiMultiChoice[i].GetComponent<AnswerButton>().DoReset();
		}

		//yield return new WaitForSeconds(1);

		//pergunta.afterQuestion.Invoke();
		myAfterQuestion.Invoke();

	}

	void AddQuestionGabarito(Pergunta perg){
		GameManager.gabarito += "<b>Pergunta: " +  perg.questao.pergunta+ "</b>";

		GameManager.gabarito += "\n \n";
		/* 
		GameManager.gabarito += "Alternativa Correta: "+ perg.questao.respostas[perg.questao.numResposta];

		GameManager.gabarito += "\n \n";*/


	}

	public void AddRespostaCerta(){
		GameManager.gabarito += "Alternativa correta: "+ pergunta.questao.respostas[pergunta.questao.numResposta];

		GameManager.gabarito += "\n_________________________________________________________\n \n";
	}
}
