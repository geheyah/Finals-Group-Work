using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;
    public int enemiesSlain = 0;
    public bool questAccepted = true;

    //private int aquasAffection = 0;
    private int foliaAffection = 0;
    private int sataniaAffection = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (missingLeaves >= 5 && questAccepted == true)
        {
            foliaAffection++;
        }

        if (enemiesSlain >= 5 && questAccepted == true)
        {
            sataniaAffection++;
        }
    }
}
