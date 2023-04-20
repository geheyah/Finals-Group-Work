using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance; // A static reference to the player GameObject

    public int missingLeaves = 0; // Declare and initialize missingLeaves to 0

    void Awake()
    {
        // Set the instance variable to this GameObject when the script is loaded
        instance = this;
    }

    // Other code for the player GameObject's behavior...
}
