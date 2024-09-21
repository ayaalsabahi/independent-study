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
        Debug.Log($"Attempting to update chapter for {playerName} to {chapter}");

        GameObject npcPlayer = GameObject.Find(playerName);
        if (npcPlayer == null)
        {
            Debug.LogError($"NPC Player not found with name: {playerName}");
            return; // Early exit if the player is not found
        }

        Player playerScript = npcPlayer.GetComponent<Player>();
        if (playerScript == null)
        {
            Debug.LogError($"Player script not found on {playerName}");
            return; // Early exit if the script is not found
        }

        playerScript.ChangeChapter(chapter);
        Debug.Log($"{playerName} chapter updated to {chapter}");

        // Additional updates can go here (e.g., updating a dictionary)
    }
}
