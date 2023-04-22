using UnityEngine;

public class NPC : MonoBehaviour
{
    public float interactionRadius = 3f; // The radius at which the player can interact with the NPC

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
            }
        }
    }
}
