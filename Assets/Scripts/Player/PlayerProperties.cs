using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    public int missingLeaves = 0;
    public int enemiesSlain = 0;

    public bool foliaComplete = false;
    public bool satanaComplete = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (missingLeaves >= 5)
        {
            foliaComplete = true;
            SceneManager.LoadScene(3);
        }

        if (enemiesSlain >= 5)
        {
            satanaComplete = true;
            SceneManager.LoadScene(4);
        }
    }
}
