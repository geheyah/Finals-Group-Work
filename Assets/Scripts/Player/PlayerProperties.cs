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

    private const string AQUAS_AFFECTION_KEY = "AquasAffection";
    private const string FOLIA_AFFECTION_KEY = "FoliaAffection";
    private const string SATANIA_AFFECTION_KEY = "SataniaAffection";

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
<<<<<<< HEAD
        // Load the value of aquasAffection from PlayerPrefs
        aquasAffection = PlayerPrefs.GetInt("AquasAffection", 0);
        foliaAffection = PlayerPrefs.GetInt("foliaAffection", 0);
        sataniaAffection = PlayerPrefs.GetInt("sataniaAffection", 0);
=======
        // Load saved affection values from PlayerPrefs
        aquasAffection = PlayerPrefs.GetInt(AQUAS_AFFECTION_KEY, 0);
        foliaAffection = PlayerPrefs.GetInt(FOLIA_AFFECTION_KEY, 0);
        sataniaAffection = PlayerPrefs.GetInt(SATANIA_AFFECTION_KEY, 0);
>>>>>>> origin/main
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
            SaveAffectionValue(FOLIA_AFFECTION_KEY, foliaAffection);
            SceneManager.LoadScene("FoliaQuestCompleteScene");
            foliaAffectionIncreased = true;

            PlayerPrefs.SetInt("foliaAffection", foliaAffection);
            PlayerPrefs.Save();
        }

        if (enemiesSlain >= 5 && questAccepted == true && !sataniaAffectionIncreased)
        {
            sataniaAffection++;
            SaveAffectionValue(SATANIA_AFFECTION_KEY, sataniaAffection);
            sataniaAffectionIncreased = true;

            PlayerPrefs.SetInt("sataniaAffection", sataniaAffection);
            PlayerPrefs.Save();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
<<<<<<< HEAD
            // SceneManager.LoadScene(22);
=======
>>>>>>> origin/main
            aquasAffection++;
            SaveAffectionValue(AQUAS_AFFECTION_KEY, aquasAffection);
            Debug.Log("you win");

            // Save the value of aquasAffection to PlayerPrefs
            PlayerPrefs.SetInt("AquasAffection", aquasAffection);
            PlayerPrefs.Save();
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

    private void SaveAffectionValue(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("AquasAffection", aquasAffection);
        PlayerPrefs.SetInt("FoliaAffection", foliaAffection);
        PlayerPrefs.SetInt("SataniaAffection", sataniaAffection);
    }
}
