using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RythmGameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScrollerScript theBS;
    public static RythmGameManager instance;

    public int currentScore;
    public int scorePerNote;

    public TextMeshProUGUI scoreText;

   


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
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
        currentScore += scorePerNote;

        scoreText.text = "Score: " + currentScore;

        Debug.Log("Hit");
    }
    public void noteMissed()
    {
        Debug.Log("note missed");
    }
}
