using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SouqGameManager : MonoBehaviour
{
    public static SouqGameManager Instance { get; private set; } // Singleton instance

    public DialogueRunner dialogueRunner;
    public Camera playerCamera; 
    public bool playerCameraSetting;


    public GameObject mainPlayer; 
    private PlayerMovement mainPlayerScript; 
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if there is already an instance of this class
        if (Instance == null)
        {
            Instance = this; // Set the instance to this
            DontDestroyOnLoad(gameObject); // Optional: Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy this instance if one already exists
        }

        dialogueRunner.AddCommandHandler(
            "updateChapter",
            (string name, int newChapter) => UpdateChapter(name, newChapter)
        );
        //get the scipt componet of the PlayerMovement Once
        mainPlayerScript = mainPlayer.GetComponent<PlayerMovement>();
        

    }

    void Start()
    {
    }

    // Updated main camera controls + pauses player movement
    public void SwitchCameraSetting()
    {
        playerCameraSetting = !playerCameraSetting;
        playerCamera.enabled = playerCameraSetting;
        mainPlayerScript.switchMovement();
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
