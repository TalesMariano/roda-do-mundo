using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteZLayers : MonoBehaviour {




	void Start () {
		GetComponent<SpriteRenderer>().sortingOrder = (int)(-transform.position.z*100);
	}
}