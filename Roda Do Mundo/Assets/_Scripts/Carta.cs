using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour {

	Quaternion startQuat;
	Quaternion endQuat;

	float startScale;
	float endScale;

	Vector3 stScale;
	Vector3 enScale;

	float startAlpha = 1;
	float endAlpha = 0;

	Vector3 startPos ;
	Vector3 endPos;


	public Transform backStuff;

	bool aberto = false;
	CanvasGroup canvasGroup ;

	public Carta[] tempOutrasCartas;



	//---------------------- Vertical Layout
	public VerticalLayoutGroup layoutGroup;


	void Start () {
		canvasGroup = GetComponent<CanvasGroup>();
		startQuat = transform.rotation;
		endQuat = Quaternion.Euler(0, 90, 0);


	stScale = transform.localScale;
	enScale = new Vector3( -1,1,1);

		startPos = transform.localPosition;
		endPos = Vector3.zero;

	}

	private void OnMouseDown()
    {
		Debug.Log("mouse down");
		Open();
	}
	
	public void Open()
    {
		
		

		if(!aberto){
			GetComponent<QuestionLoader>().ChamouCarta();
			foreach(Carta c in tempOutrasCartas) c.Hide(0.25f);
			aberto = true;
			RotateCard();
			print(name);
			StartCoroutine(IMoveCenter(1));
		}
	}


	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKeyDown(KeyCode.K)){
			RotateCard();//StartCoroutine(IRotateCard(2));
		}

		if(Input.GetKeyDown(KeyCode.L)){
			//RotateCard();//StartCoroutine(IRotateCard(2));
			print("foi");
			//transform.localPosition = Vector3.zero;
			StartCoroutine(IEHide(1));
		}*/

	}



	[ContextMenu("Rotate")]
	public void RotateCard(){

		startQuat = transform.rotation;
		endQuat = startQuat *  Quaternion.Euler(0, 180, 0);

		startScale = transform.localScale.x;
		endScale = -startScale/startScale;

		//StartCoroutine(IRotateCard(1));
		StartCoroutine(IScaleCard(1));

	}

	[ContextMenu("Reset")]
	public void Reset(){
		transform.localScale = stScale;
		aberto = false;
		if(canvasGroup != null)
			canvasGroup.alpha = endAlpha;
		transform.localPosition =  startPos;
		backStuff.gameObject.SetActive(false);
	}


	IEnumerator IRotateCard(float duration){
		float step = 0;
		bool changeBack = true;
		while(step < duration){
			step += Time.deltaTime;
			//print(step);
	
			if(changeBack && step>duration/2){
				print(step);

				layoutGroup.enabled = false;
				yield return new WaitForEndOfFrame();
				Debug.LogError("erro");
				layoutGroup.enabled = true;
				yield return new WaitForEndOfFrame();
				Debug.LogError("erro");
				layoutGroup.enabled = false;
				yield return new WaitForEndOfFrame();
				Debug.LogError("erro");
				layoutGroup.enabled = true ;
				yield return new WaitForEndOfFrame();
				Debug.LogError("erro");

				/* 
				layoutGroup.CalculateLayoutInputVertical();
				yield return null;
				layoutGroup.SetLayoutVertical();
				yield return null;
				*/
				changeBack = false;
				if(backStuff!= null)
					backStuff.gameObject.SetActive(!backStuff.gameObject.activeInHierarchy);
			}
			/* 
			layoutGroup.CalculateLayoutInputVertical();
			yield return null;
			layoutGroup.SetLayoutVertical();
			//yield return null;

			transform.rotation = Quaternion.Slerp(startQuat,endQuat,step/duration);
			yield return null;*/
		}
	}

	IEnumerator IScaleCard(float duration){
		float step = 0;
		bool changeBack = true;



		while(step < 1){
			step += Time.deltaTime/duration;
			//print(step);
	
			if(changeBack && step>duration/2){
				//print(step);
				/* 
				layoutGroup.CalculateLayoutInputVertical();
				yield return null;
				Debug.LogError("erro");
				layoutGroup.SetLayoutVertical();
				yield return null;
				*/

				StartCoroutine(LayoutG());


				changeBack = false;
				if(backStuff!= null)
					backStuff.gameObject.SetActive(!backStuff.gameObject.activeInHierarchy);
			}

			//transform.rotation = Quaternion.Slerp(startQuat,endQuat,step/duration);
			transform.localScale = Vector3.Slerp(stScale,enScale,step); //new Vector3(Mathf.SmoothStep(startScale, endScale, step),1,1);
			yield return null;
		}
	}


	IEnumerator LayoutG(){
				layoutGroup.enabled = false;
				yield return null;// new WaitForEndOfFrame();
				//yield return new WaitForSeconds(0.25f);
				//Debug.LogError("erro");
				layoutGroup.enabled = true;
				yield return null;//new WaitForEndOfFrame();
				//yield return new WaitForSeconds(0.25f);
				//Debug.LogError("erro");
				layoutGroup.enabled = false;
				yield return null;//new WaitForEndOfFrame();
				//yield return new WaitForSeconds(0.25f);
				//Debug.LogError("erro");
				layoutGroup.enabled = true ;
				yield return null;//new WaitForEndOfFrame();
				//yield return new WaitForSeconds(0.25f);
				//Debug.LogError("erro");
	}

	[ContextMenu("Hide")]
	public void Hide(){
		StartCoroutine(IEHide(0.5f));
	}

	public void Hide(float dur){
		StartCoroutine(IEHide(dur));
	}


	[ContextMenu("Show")]
	public void Show(){
		//StartCoroutine(IEHide(1));
		Reset();
		canvasGroup.alpha = startAlpha;
		ChangeToggles(true);
	}

	void ChangeToggles(bool b){
		canvasGroup.interactable = b;
		canvasGroup.blocksRaycasts = b;
	}

	IEnumerator IEHide(float duration){
		float step = 0;
		ChangeToggles(false);
		float newStartAlpha = canvasGroup.alpha;
		while(step < duration){
			step += Time.deltaTime;
			canvasGroup.alpha = Mathf.SmoothStep(newStartAlpha,endAlpha,step/duration);
			yield return null;
		}
		
		//canvasGroup.interactable = false;
	}

	IEnumerator IMoveCenter(float duration){
		float step = 0;

		

		//bool changeBack = true;
		while(step < 1){
			step += Time.deltaTime/duration;
			//print(step);
			/* 
			if(changeBack && step>duration/2){
				print(step);
				changeBack = false;
				if(backStuff!= null)
					backStuff.gameObject.SetActive(!backStuff.gameObject.activeInHierarchy);
			}*/

			//transform.rotation = Quaternion.Slerp(startQuat,endQuat,step/duration);
			transform.localPosition =  Vector3.Slerp(startPos, endPos, step);
			yield return null;
		}

	}
}
