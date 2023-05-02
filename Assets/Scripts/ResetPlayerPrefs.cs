using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    private bool isReset = false;

    void Start()
    {
        if (!isReset)
        {
            PlayerPrefs.DeleteKey("AquasAffection");
            PlayerPrefs.DeleteKey("FoliaAffection");
            PlayerPrefs.DeleteKey("SataniaAffection");
            isReset = true;
        }
    }
}
