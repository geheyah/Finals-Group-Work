using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmGameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScrollerScript theBS;

    public static RythmGameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }
    public void noteHit()
    {
        Debug.Log("Hit");
    }
    public void noteMissed()
    {
        Debug.Log("note missed");
    }
}
