using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Quest {

    public string questName;
    public string questDescription;

    public int objectives;
    public int objectivesComplete;

    public enum QuestType {Fetch, Kill, }

    void Start()
    {
        
    }
}
