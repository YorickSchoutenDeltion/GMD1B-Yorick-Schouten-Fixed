using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> reference = new List<GameObject>();
    public List<GameObject> actual = new List<GameObject>();

    public int keyLog;

    public bool CheckList()
    {
        keyLog = 0;
        for(int i = 0; i < actual.Count; i++)
        {
            if(actual[i] != null)
            {
                keyLog++;
            }

            else
            {
                break;
            }
        }
        if (keyLog == 3)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

}
