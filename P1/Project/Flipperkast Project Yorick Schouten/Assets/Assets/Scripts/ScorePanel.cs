using UnityEngine;
using System.Collections;

public class ScorePanel : MonoBehaviour {
    public void OnCollisionEnter()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
        GameObject.Find("ScoreBoardText").GetComponent<Scoreboard>().UpdateScoreboard();
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
    }
}
