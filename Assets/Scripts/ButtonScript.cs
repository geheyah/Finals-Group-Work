using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("App Exit");
    }
}
