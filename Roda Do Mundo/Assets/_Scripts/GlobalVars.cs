using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour {

	public static bool casa;

	public static int nota;

	public static int maxNota = 7;

	public static int gRot = 0;

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BoolCasa(bool bo){
		casa = bo;
	}

	public void GlobalReset(){
		nota = 0;
		gRot = 0;
	}

	public void ResetRotation(){
		gRot = 0;
	}

	public void NotaPlus(){
		nota++;
	}
}
