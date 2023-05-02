using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;
    public int enemiesSlain = 0;
    public bool questAccepted = true;

    public int aquasAffection = 0;
    public int foliaAffection = 0;
    public int sataniaAffection = 0;
    public TextMeshProUGUI leafFound;

    // Flags to ensure affection points only increase once
    private bool foliaAffectionIncreased = false;
    private bool sataniaAffectionIncreased = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {

        if (leafFound != null)
        {
            leafFound.text = "Missing Leaves: " + missingLeaves.ToString() + " /5";
        }

        if (missingLeaves >= 5 && questAccepted == true && !foliaAffectionIncreased)
        {
            foliaAffection++;
            SceneManager.LoadScene("FoliaQuestCompleteScene");
            foliaAffectionIncreased = true;
        }

        if (enemiesSlain >= 5 && questAccepted == true && !sataniaAffectionIncreased)
        {
            sataniaAffection++;
            sataniaAffectionIncreased = true;
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
