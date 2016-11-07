using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

    private ParticleSystem pc;

    public void Start()
    {
        pc = GetComponent<ParticleSystem>();
        pc.playOnAwake = false;
    }

    public void OnCollisionEnter ()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
        GameObject.Find("ScoreBoardText").GetComponent<Scoreboard>().UpdateScoreboard();
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
        pc.Emit(240);
    }
}
