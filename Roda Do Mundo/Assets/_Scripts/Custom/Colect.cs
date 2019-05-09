using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Colect : MonoBehaviour {

	public AnimationCurve aCurve;

	public Transform target;

	Vector3 startPos;

	float duration = 2;

	public bool go = false;

	float step = 0;

	public UnityEvent endAction;

	bool once = true;

	[ContextMenu("context")]
	public void DoMove(){
		if(once){
			StartCoroutine(Move(startPos));
			once= false;
		}
	}


	IEnumerator Move(Vector3 endPos){
		//startPos
		//Vector3 endPos;
		startPos = transform.position;
		endPos = target.position;

		float t = 0;

		while (t<duration){

			transform.position = Vector3.Lerp(startPos, endPos, aCurve.Evaluate(  t/duration));
			transform.localScale = Vector3.one * (1-(aCurve.Evaluate(  t/duration)));

			t += Time.deltaTime;
			yield return new WaitForEndOfFrame();

		}

		endAction.Invoke();

		gameObject.SetActive(false);	

	}
}
