using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceBtnScript : MonoBehaviour
{
    public void acceptAquasChoice()
    {
        SceneManager.LoadScene(10);
    }
    public void declinedAquasChoice()
    {
        SceneManager.LoadScene(5);
    }
    public void aquasCompletionQuestBtn()
    {
        SceneManager.LoadScene(5);
    }

    //=====================================================================

    public void acceptFoliaChoice()
    {
        SceneManager.LoadScene(19);
    }
    public void declinedFoliaChoice()
    {
        SceneManager.LoadScene(3);
    }
    public void foliaCompletionQuestBtn()
    {
        SceneManager.LoadScene("FoliaQuestDone");
    }

    //=====================================================================

    public void acceptSatanaChoice()
    {
        SceneManager.LoadScene("SatanaQuestInProgress");
    }
    public void declinedSatanaChoice()
    {
        SceneManager.LoadScene("SatanaLevel");
    }
    public void SatanaCompletionQuestBtn()
    {
        SceneManager.LoadScene("SatanaQuestDone");
    }
}

