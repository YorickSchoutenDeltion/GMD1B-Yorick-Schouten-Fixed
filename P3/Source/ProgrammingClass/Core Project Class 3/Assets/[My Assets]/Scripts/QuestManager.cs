using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public List<Quest> questList = new List<Quest>();

    void Start()
    {
        questList.Add(new Quest());
    }
}
