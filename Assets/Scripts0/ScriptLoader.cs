using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ScriptLoader : MonoBehaviour
{

    public bool spokenToRedBool = false;
    public bool goodChoiceBool = false;
    public DialogueRunner dialogueRunner; //drag and drop dialgoue runner here

    // [YarnCommand("SpokeToRed")]

   private void Awake()
    {
        // Register command handlers with parameters if needed
        dialogueRunner.AddCommandHandler(
            "SpokeToRed", // the name of the command
            () => SpokeToRed() // lambda expression to call the method
        );

        dialogueRunner.AddCommandHandler(
            "GoodChoice",
            () => GoodChoice() // lambda expression to call the method
        );
    }

    public void SpokeToRed(){
        spokenToRedBool = true;
        //maybe make sure it does not pop up again somehow?? 
    }

    // [YarnCommand("GoodChoice")]
    public void GoodChoice(){
        goodChoiceBool = true; 
    }

}


    //a different method for invocation of functions, but redundant 
   