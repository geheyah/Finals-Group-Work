using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youWinScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            SceneManager.LoadScene(22);

            Debug.Log("you win");
        }
    }
}
