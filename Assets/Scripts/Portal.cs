using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextSceneName;
    public bool showMouseOnEnter = false;

    private bool cursorWasLocked = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered portal");
            if (showMouseOnEnter)
            {
                Cursor.visible = true; // Show mouse cursor
                Cursor.lockState = CursorLockMode.None; // Unlock cursor to allow movement
                cursorWasLocked = false; // Remember that cursor was not locked before
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited portal");
            if (showMouseOnEnter && !cursorWasLocked)
            {
                Cursor.visible = false; // Hide mouse cursor
                Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
                cursorWasLocked = true; // Remember that cursor was locked before
            }
        }
    }
}
