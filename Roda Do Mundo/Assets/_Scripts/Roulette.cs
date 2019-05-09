using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Roulette : MonoBehaviour {

	public float targetNumber = 1;

	public bool stop;
	public bool trueStop = true;

	public bool ein = false;

	public float zAngle;

	float speed = 0;
	float baseSpeed = 400;

	public float stopnumber;

	public UnityEvent endSpinEvent;

	// Use this for initialization
	void Start () {
		//speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.forward, speed* Time.deltaTime);

		zAngle = transform.localEulerAngles.z; //old euler


		//PArando rotacao
		if(stop && speed >0)
			speed -=baseSpeed*Time.deltaTime;//speed -= Time.timeScale;

		if(speed <= 0 && !trueStop)
			Stopped();


		if(ein){
			
			PrepareStop();
			
			if(zAngle>stopnumber && zAngle<stopnumber+(0.04f *360f)){ //14?0.14
				print("stopnumber: " + stopnumber  + " < zAngle:" + zAngle + " < max:" + (stopnumber+(0.04f *360f)));
				stop = true;
				ein = false;
			}
		}
		/* 
		if(Input.GetKeyDown(KeyCode.Z))
			DoStop();

		if(Input.GetKeyDown(KeyCode.X)){
			Move();
		}*/

	}

	[ContextMenu("DoStop")]
	public void DoStop(){
		ein = true;
	}

	[ContextMenu("Move")]
	public void Move(){
		speed = baseSpeed;
		ein = false;
		stop = false;
		trueStop = false;
	}

	public void PrepareStop(){
		stopnumber = (targetNumber )*380/7 ;//normalized
		//stopnumber = stopnumber -1;
		//stopnumber = stopnumber*360;

	}

	public void RecebeNum(int num){
		//fazer questaõ do numero ser certo, de 1 a 7
		targetNumber = num;
		DoStop();

	}

	void Stopped(){
		trueStop = true;
		speed = 0;
		GameManager.ParouRoleta();
		endSpinEvent.Invoke();
	}
}
