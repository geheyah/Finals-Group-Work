using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButton : MonoBehaviour
{
    public string characterName;

    void OnMouseDown()
    {
        if (PlayerProperties.instance.GetAffectionLevel(characterName) >= 1)
        {
            SceneManager.LoadScene(characterName + "Good");
            Debug.Log(characterName + " Good Ending");
        }
        else
        {
            SceneManager.LoadScene(characterName + "Bad");
            Debug.Log(characterName + " Bad Ending");
        }
    }
}
