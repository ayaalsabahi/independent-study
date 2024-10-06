using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class Player : MonoBehaviour
{
    private string playerName;
    private int currentChapter; 
    public DialogueRunner dialogueRunner;
    private string newChapterStr;
    private bool nextChapter;
    private Camera myCamera; 
    private string cameraName; //we can have different setups for different players so have different cameras later on

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
        cameraName = name + "Camera"; 
        Debug.Log("Camera name is: " + cameraName);
        GameObject cameraObject = GameObject.Find(cameraName); //get the camera specifc to the each setup players name

        if(cameraObject == null){
            Debug.Log("CAMERA IS NULL!");
        }

        this.myCamera = cameraObject.GetComponent<Camera>();

        this.myCamera.enabled = false; 

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
                myCamera.enabled = true; //have to change this here to be the same camera for all!!!!
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
       


        
    }
}
