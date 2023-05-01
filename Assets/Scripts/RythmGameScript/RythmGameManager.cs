using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public float soundDelay;

    public float noteDamage;
    public float playerHealth;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    public Transform hitPosEffect1;
    public Transform hitPosEffect2;
    public Transform hitPosEffect3;
    public Transform hitPosEffect4;

    public GameObject hitEffect1;
    public GameObject hitEffect2;
    public GameObject hitEffect3;
    public GameObject hitEffect4;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        healthText.text = "Health: 10";
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


                Invoke("DelayedStartPlaying", soundDelay);
            }
        }
    }
    public void noteHit()
    {

        if (Random.Range(0f, 1f) < 0.20) // 0.20 chance on getting your health back 
        {
            playerHealth += 2;
            healthText.text = "Health: " + playerHealth;

            Debug.Log("add health");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(hitEffect1, hitPosEffect1.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(hitEffect2, hitPosEffect2.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(hitEffect3, hitPosEffect3.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(hitEffect4, hitPosEffect4.position, Quaternion.identity);
        }

        currentScore += scorePerNote;

        scoreText.text = "Score: " + currentScore;

        Debug.Log("Hit");
    }
    public void noteMissed()
    {
        Debug.Log("note missed");

        playerHealth -= noteDamage;
        healthText.text = "Health: " + playerHealth;
        
        if(playerHealth <= 0 )
        {
            Debug.Log("You Lose");

            startPlaying = false;
            theMusic.Stop();
            //SceneManager.LoadScene(5);
            //transition to defeat screen and ask the player to replay or quit
        }
    }

    void DelayedStartPlaying()
    {
        theMusic.Play();
    }
}
