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
         PlayerProperties.instance.aquasAffection = PlayerPrefs.GetInt("aquasAffection");
         PlayerProperties.instance.foliaAffection = PlayerPrefs.GetInt("foliaAffection");
         PlayerProperties.instance.sataniaAffection = PlayerPrefs.GetInt("sataniaAffection");
     }


    // You can add other functions here to save or modify the affection points as well
}
