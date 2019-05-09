using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteButton : MonoBehaviour {

    public Button button;
    
    private bool canCoroutine = true;
    
    private void Update()
    {
        if(button.interactable && canCoroutine)
        {            
            StartCoroutine(WaitToEnable());
        }

        if(!button.interactable && !canCoroutine)
        {
            canCoroutine = true;
        }
    }

    private IEnumerator WaitToEnable()
    {
        canCoroutine = false;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Enter");
        button.Select();
    }
}
