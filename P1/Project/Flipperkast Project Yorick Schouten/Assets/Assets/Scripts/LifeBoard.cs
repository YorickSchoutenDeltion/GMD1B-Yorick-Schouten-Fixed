using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeBoard : MonoBehaviour
{

    public string displayStringL;
    public Text scoreDisplayL;

    public void Start()
    {
        displayStringL = 0.ToString();
    }

    public void Update()
    {
        displayStringL = GameObject.Find("GameManager").GetComponent<GameManager>().lives.ToString();
        scoreDisplayL.text = displayStringL;
    }

}
