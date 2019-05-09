using System.Collections;
using UnityEngine;

public class OpenLink : MonoBehaviour {

	public void Open(string link){
		 Application.OpenURL(link);
	}

}
