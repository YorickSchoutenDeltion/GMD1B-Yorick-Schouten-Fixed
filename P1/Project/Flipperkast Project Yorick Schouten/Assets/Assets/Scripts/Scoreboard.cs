using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public string displayString;
    public Text scoreDisplay;

    public void Start()
    {
        displayString = 0.ToString();
        UpdateScoreboard();
    }

    public void UpdateScoreboard()
    { 
        displayString = GameObject.Find("GameManager").GetComponent<GameManager>().score.ToString();
        scoreDisplay.text = displayString;
    }

}
