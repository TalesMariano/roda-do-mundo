using System.Collections;
using UnityEngine;

public class ListaPerguntas : MonoBehaviour {

	public Pergunta[] facil;
	int numFacil;
	public Pergunta[] medio;
	int numMedio;
	public Pergunta[] dificil;
	int numDificil;

	void Start(){
		numFacil = facil.Length;
		numMedio = medio.Length;
		numDificil = dificil.Length;


		facil = Shuffle(facil);
		medio= Shuffle(medio);
		dificil= Shuffle(dificil);
	}


	
	public Pergunta PerguntaDificuldade(int dif){
		if(dif == 2)
			return PegaDificil();
		else if (dif == 1)
			return PegaMedio();
		else //if(dif == 0)
			return PegaFacil();
		//else 
			//return Debug.LogException("Número de dificuldade errado");
	}


	public Pergunta PegaDificil(){
		//Pergunta retorno;
		if(numDificil > 0){
			numDificil --;
			return dificil[numDificil];
		}else{
			return PegaMedio();
		}
	}

	public Pergunta PegaMedio(){
		//Pergunta retorno;
		if(numMedio > 0){
			numMedio --;
			return medio[numMedio];
		}else{
			return PegaFacil();
		}
	}

	public Pergunta PegaFacil(){
		//Pergunta retorno;
		if(numFacil > 0){
			numFacil --;
			return facil[numFacil];
		}else{
			return facil[facil.Length-1];
			//return PegaMedio();
		}
	}

	Pergunta[] Shuffle(Pergunta[] a)
	{		
		// Loops through array
		for (int i = a.Length-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			Pergunta temp = a[i];
			
			// Swap the new and old values
			a[i] = a[rnd];
			a[rnd] = temp;
		}
		
		return a;
	}


}
