using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aquasQuest : MonoBehaviour
{
    public float interactionRadius = 3f; // The radius at which the player can interact with the NPC

    public string[] dialogue; // Array of dialogue lines to display when interacting with the NPC
    public bool questAvailable; // Flag to indicate if a quest is available from the NPC
    public string questTitle; // The title of the quest
    public string questDescription; // The description of the quest

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
                Debug.Log("Interacted with NPC");
                SceneManager.LoadScene(9);
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
            SceneManager.LoadScene(6);  //go to rythm game scene
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Quest declined.");
        }
    }
}
