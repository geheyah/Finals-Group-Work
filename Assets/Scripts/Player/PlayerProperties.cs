using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;

    void Awake()
    {
        instance = this;
    }

}
