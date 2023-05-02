using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadAffectionPoints();
    }

    void LoadAffectionPoints()
    {
        PlayerProperties.instance.aquasAffection = PlayerPrefs.GetInt("AquasAffection", 0);
        PlayerProperties.instance.foliaAffection = PlayerPrefs.GetInt("FoliaAffection", 0);
        PlayerProperties.instance.sataniaAffection = PlayerPrefs.GetInt("SataniaAffection", 0);
    }

    // You can add other functions here to save or modify the affection points as well
}
