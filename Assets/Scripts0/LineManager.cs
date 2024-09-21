using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LineManager : MonoBehaviour
{

    public DialogueRunner dialogueRunner;

    public Transform redTrans; 
    public Transform greenTrans;
    public Transform playerTrans;
    public float thresHold = 3.0f; 

    public ScriptLoader scriptLoader;

    private bool redDialogueStarted = false; 
    private bool greenDialogueStarted = false;

    private void Update() {

        
        //get the transform of the players 
        GameObject redObj = GameObject.FindGameObjectWithTag("red");
        GameObject greenObj = GameObject.FindGameObjectWithTag("green");
        GameObject playerObj = GameObject.FindGameObjectWithTag("player");

        redTrans = redObj.transform;
        greenTrans = greenObj.transform;
        playerTrans = playerObj.transform;

        //will optimize this later on...
        if (isClose(redTrans, playerTrans) && !redDialogueStarted){
            
            if(!scriptLoader.spokenToRedBool){
               dialogueRunner.StartDialogue("redStart");
               
            }
            else{
                dialogueRunner.StartDialogue("redEnd");
                
            }
            redDialogueStarted = true;
        }
        if (isClose(greenTrans,playerTrans)){
            if(!scriptLoader.spokenToRedBool){

                dialogueRunner.StartDialogue("blueStart");
                //run the dialogue of  speaking to red
            }
            else{
                if(scriptLoader.goodChoiceBool){
                    dialogueRunner.StartDialogue("goodChoice");
                }
                else{
                    dialogueRunner.StartDialogue("badChoice");
                }
            }

        }

       
        
    }

    private bool isClose(Transform p1, Transform p2){
        float dist = (p1.position - p2.position).sqrMagnitude;
        return dist <= (thresHold*thresHold);

    }
   
}
