using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Yarn.Unity;

public class Player : MonoBehaviour
{
    private string playerName;
    private int currentChapter; 
    public DialogueRunner dialogueRunner;
    private string newChapterStr;
    private bool nextChapter;
    private Camera myCamera; 

    private void Start()
    {
        // Initialize playerName based on the GameObject name
        Initialize(gameObject.name);
    }

    public void Initialize(string name)
    {
        this.playerName = name;
        this.currentChapter = 1;
        this.nextChapter = true;
        //get the mycamera instance 
        this.myCamera = GetComponentInChildren<Camera>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name == "MainPlayer") // Assuming "MainPlayer" is the player character's name
        {
            // Constructing the chapter string based on the current chapter
            newChapterStr = playerName + currentChapter.ToString();

            //only run if we have a next chapter
            if(nextChapter){
                dialogueRunner.StartDialogue(newChapterStr);
                //turn off players camera
                SouqGameManager.Instance.SwitchCameraSetting();
                //turn on my camera
                myCamera.enabled = true; 
            }
            
            nextChapter = false; 
        }
    }

    public void ChangeChapter(int newChapter)
    {
        if (newChapter != -1){
            nextChapter = true; 
            currentChapter = newChapter;
        }
        
        Debug.Log("called switched camera setting");
        SouqGameManager.Instance.SwitchCameraSetting();
        myCamera.enabled = false;
    }

    public void OnTriggerExit(Collider other) 
    {
        // Implement any logic for when the player exits the proximity of the NPC
        dialogueRunner.Stop();

        //my camera off
       


        
    }
}
