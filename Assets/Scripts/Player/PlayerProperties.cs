using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;
    public bool leavesComplete = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (missingLeaves >= 5)
        {
            leavesComplete = true;
        }
    }
}
