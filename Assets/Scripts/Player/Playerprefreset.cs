using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerprefreset : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
    }
}
