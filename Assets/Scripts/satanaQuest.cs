using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class satanaQuest : MonoBehaviour
{
    public float interactionRadius = 3f; // The radius at which the player can interact with the NPC

    public string[] dialogue; // Array of dialogue lines to display when interacting with the NPC
    public bool questAvailable; // Flag to indicate if a quest is available from the NPC
    public string questTitle; // The title of the quest
    public string questDescription; // The description of the quest
    public static NPC instance;

    private bool isInRange = false; // Flag to indicate if the player is in range of the NPC

    void Update()
    {
        // Check if the player is in range of the NPC
        float distance = Vector3.Distance(transform.position, PlayerProperties.instance.transform.position);
        if (distance <= interactionRadius)
        {
            isInRange = true;
            Interact();
        }
        else
        {
            isInRange = false;
        }
    }

    // Draw a wire sphere in the editor to visualize the interaction radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    void Interact()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(6);
                Debug.Log("Interacted with NPC");
                DisplayDialogue();
                if (questAvailable)
                {
                    DisplayQuest();
                }
            }
        }
    }

    void DisplayDialogue()
    {
        // Loop through the dialogue array and display each line
        foreach (string line in dialogue)
        {
            Debug.Log(line);
        }
    }

    void DisplayQuest()
    {
        // Offer the quest to the player
        Debug.Log("Would you like to accept the quest: " + questTitle);
        Debug.Log(questDescription);

        // Wait for the player's response
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Quest accepted!");
            // TODO: Add code to activate the quest
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Quest declined.");
        }
    }
}
