using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;
    public int enemiesSlain = 0;
    public bool questAccepted = true;

    private bool leavesQuestComplete = false;
    private bool enemiesQuestComplete = false;

    public int aquasAffection = 0;
    public int foliaAffection = 0;
    public int sataniaAffection = 0;

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

    public int GetAffectionLevel(string characterName)
    {
        switch (characterName)
        {
            case "Aquas":
                return aquasAffection;
            case "Folia":
                return foliaAffection;
            case "Satania":
                return sataniaAffection;
            default:
                return 0;
        }

    }
}
