using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;
    public int enemiesSlain = 0;
    public bool questAccepted = true;

    public bool foliaComplete = false;
    public bool satanaComplete = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (missingLeaves >= 5 && questAccepted == true)
        {
            foliaComplete = true;
        }

        if (enemiesSlain >= 5 && questAccepted == true)
        {
            satanaComplete = true;
        }
    }
}
