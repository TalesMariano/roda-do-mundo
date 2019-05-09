using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstSelectableButton : MonoBehaviour {

    public Button button;

    private void Start()
    {
        button.Select();
    }
}
