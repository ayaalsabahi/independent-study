using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Player : MonoBehaviour
{
    private string playerName;
    private int currentChapter; 
    public DialogueRunner dialogueRunner;
    private string newChapterStr;

    private void Start()
    {
        // Initialize playerName based on the GameObject name
        Initialize(gameObject.name);
    }

    public void Initialize(string name)
    {
        this.playerName = name;
        this.currentChapter = 1;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name == "MainPlayer") // Assuming "MainPlayer" is the player character's name
        {
            // Constructing the chapter string based on the current chapter
            newChapterStr = playerName + "Chapter" + currentChapter.ToString();
            Debug.Log(" new chapter name is:" + newChapterStr);
            dialogueRunner.StartDialogue(newChapterStr);
        }
    }

    public void ChangeChapter(int newChapter)
    {
        currentChapter = newChapter;
    }

    public void OnTriggerExit(Collider other) 
    {
        // Implement any logic for when the player exits the proximity of the NPC
         dialogueRunner.StopDialogue();
    }
}
