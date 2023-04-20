using UnityEngine;

public class MissingLeaf : MonoBehaviour
{
    public float interactionRadius = 3f; // The radius at which the player can interact with the object

    private bool isInRange = false; // Flag to indicate if the player is in range of the object

    void Update()
    {
        // Check if the player is in range of the object
        float distance = Vector3.Distance(transform.position, PlayerProperties.instance.transform.position);
        if (distance <= interactionRadius)
        {
            isInRange = true;
            obtainLeaf();
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

    void obtainLeaf()
    {
        if (isInRange == true)
        {
            // Check if the player presses the E key while in range
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Increase the missingLeaves count in the PlayerProperties script
                PlayerProperties.instance.missingLeaves++;

                // Destroy the object and perform any other necessary actions
                Destroy(gameObject);
            }
        }
    }
}
