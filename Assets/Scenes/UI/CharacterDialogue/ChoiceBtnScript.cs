using System.Collections;
using System.Collections.Generic;
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
}
