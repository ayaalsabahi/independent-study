using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    private void Awake()
    {
        dialogueRunner.AddCommandHandler(
            "updateChapter",
            (string name, int newChapter) => UpdateChapter(name, newChapter)
        );
    }

    public void UpdateChapter(string playerName, int chapter)
    {
        //add null handling if needed for debugging later :)
        GameObject npcPlayer = GameObject.Find(playerName);
        Player playerScript = npcPlayer.GetComponent<Player>();
        playerScript.ChangeChapter(chapter);

        // Additional updates can go here (e.g., updating a dictionary)
    }
}
