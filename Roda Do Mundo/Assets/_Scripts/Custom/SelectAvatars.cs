using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatars : MonoBehaviour {

	public int numAvatarSelect = 0;

	public Transform selection;

	public Transform[] avatars;


	public void Select(int numAvatar){

		numAvatarSelect = numAvatar;

		if(numAvatarSelect < 0){
			selection.position = Vector3.one * -1000;
		}else if(numAvatarSelect < avatars.Length){
			selection.position = avatars[numAvatarSelect].position;
		}else{
			selection.position = Vector3.one * -1000;
		}

	}
}
