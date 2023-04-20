using UnityEngine;

public class FoliaScript : MonoBehaviour
{
    public string questName;
    public int missingLeavesRequired;
    public int affectionPointReward;

    private bool hasQuest = false;
    private bool hasCompletedQuest = false;
    private int currentMissingLeaves = 0;
    private bool isInteracting = false;
    private bool isAccepted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasQuest && !hasCompletedQuest)
        {
            isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasQuest && !hasCompletedQuest)
        {
            isInteracting = false;
        }
    }

    private void OnGUI()
    {
        if (isInteracting)
        {
            GUI.Box(new Rect(0, 0, 200, 50), "Press E to interact.");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!hasQuest && !hasCompletedQuest)
                {
                    DisplayQuestDialogue();
                }
            }
        }
    }

    private void DisplayQuestDialogue()
    {
        GUI.Box(new Rect(0, 0, 200, 50), "Hello! Can you help me?");
        GUI.Box(new Rect(0, 60, 200, 50), "Quest: " + questName);
        GUI.Box(new Rect(0, 120, 200, 50), "Missing Leaves: " + currentMissingLeaves + "/" + missingLeavesRequired);

        if (GUI.Button(new Rect(0, 180, 100, 50), "Accept"))
        {
            isAccepted = true;
            hasQuest = true;
            isInteracting = false;
            Debug.Log("Quest Accepted!");
        }

        if (GUI.Button(new Rect(100, 180, 100, 50), "Decline"))
        {
            isAccepted = false;
            hasQuest = false;
            isInteracting = false;
            Debug.Log("Quest Declined.");
        }
    }

    public void IncrementMissingLeaves()
    {
        currentMissingLeaves++;

        if (currentMissingLeaves >= missingLeavesRequired)
        {
            hasCompletedQuest = true;
            hasQuest = false;
            currentMissingLeaves = 0;
            isAccepted = false;
            isInteracting = true;
            Debug.Log("Quest Completed!");
        }
    }

    public int GetAffectionPointReward()
    {
        return affectionPointReward;
    }

    public bool IsQuestAccepted()
    {
        return isAccepted;
    }
}
