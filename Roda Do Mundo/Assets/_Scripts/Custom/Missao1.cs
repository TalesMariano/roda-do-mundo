using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missao1 : MonoBehaviour {

	public Missions missions;

	public bool[] quatrobutts = new bool[4];

	public void ButtUp(){
		quatrobutts[0] = true;
		CheckAllBools();
	}

	public void ButtDown(){
		quatrobutts[2] = true;
		CheckAllBools();
	}

	public void ButtLeft(){
		quatrobutts[3] = true;
		CheckAllBools();
	}

	public void ButtRight(){
		quatrobutts[1] = true;
		CheckAllBools();
	}

	void CheckAllBools(){

		if(quatrobutts[0] && quatrobutts[1] && quatrobutts[2] && quatrobutts[3]){
			missions.EndMission(0);
			Destroy (this);
		}

	}


}
