using UnityEngine;
using UnityEngine.UI;

public class TextButtonAlpha : MonoBehaviour {

	float alpha = 0;
	Button butt;
	CanvasGroup cg;


	// Use this for initialization
	void Start () {
		butt = GetComponent<Button>();
		cg = GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		if(butt.interactable){
			if(alpha < 1)
				alpha += Time.deltaTime*1.5f;
			//cg.alpha = alpha;
		}else
			alpha =0;
		cg.alpha = alpha;

	}
}
