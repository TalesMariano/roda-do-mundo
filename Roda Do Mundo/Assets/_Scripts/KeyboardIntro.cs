using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardIntro : MonoBehaviour {
    public Selectable[] selectableObject;

    private int index = 0;
    private bool isSelected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (index == 0)
            {
                selectableObject[0].OnDeselect(null);
                selectableObject[1].Select();
                index = 1;
            }
            else if(index == 1)
            {
                selectableObject[0].Select();
                selectableObject[1].OnDeselect(null);
                index = 0;
            }
        }
    }

}
