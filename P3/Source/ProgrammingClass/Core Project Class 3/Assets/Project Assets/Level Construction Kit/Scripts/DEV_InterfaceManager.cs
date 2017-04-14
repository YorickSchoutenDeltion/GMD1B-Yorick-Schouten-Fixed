using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEV_InterfaceManager : MonoBehaviour {

    public Text displayText;

    public void DisplayText(string s)
    {
        displayText.text = s;
    }

}
