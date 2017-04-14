using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_DialogueManager : MonoBehaviour {

    public DEV_InterfaceManager interfaceManager;

    public GameObject player;

    private List<string> dial = new List<string>();

    public int currentIndex;
    public int currentLayer;
    public int maxLayer;

    public bool lastText;

    void Start()
    {
        interfaceManager = GameObject.FindWithTag("Managers").GetComponent<DEV_InterfaceManager>();
        player = GameObject.FindWithTag("Player");
    }

    // This initiates the dialogue
    public void StartDialogue(GameObject g)
    {
        dial = g.GetComponent<DEV_DialogueContainer>().dialogue;
        interfaceManager.displayText.text = dial[0];
    }

    // This continues the dialogue
    public void ProgressDialogue(int i)
    {
        if (currentLayer < maxLayer)
        {
            currentIndex += (i * currentLayer);
            interfaceManager.displayText.text = dial[currentIndex];
            currentLayer++;
        }
        else
        {
            CloseDialogue();
        }
    }
    
    // This closes out the dialogue and resets the manager
    public void CloseDialogue()
    {
        currentLayer = 1;
        currentIndex = 0;
        interfaceManager.displayText.text = null;
    }

    public void TurnHostile(GameObject g)
    {
        
    }
}
