using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score;
    public int lives;
    public bool saviorRight;
    public bool saviorLeft;

    public void Start()
    {
        score = 0;
        lives = 5;
        saviorRight = true;
        saviorLeft = true;
    }

    public void AddScore()
    {
        if (!(score == 2900))
        {
            score += 100;
        }
        else
        {
            score += 100;
            GameObject.Find("BonusBallSpawner").GetComponent<BonusBall>().ExtraBall();
        }
    }


}
