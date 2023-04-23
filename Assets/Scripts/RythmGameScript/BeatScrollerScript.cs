using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScrollerScript : MonoBehaviour
{
    public GameObject[] notes;
    public Transform[] spawnPoints;
    public bool hasStarted;

    public float spawnInterval; // The time between spawns

    private float timeSinceLastSpawn; // The time since the last spawn

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            // Update the time since last spawn
            timeSinceLastSpawn += Time.deltaTime;

            // If the time since last spawn is greater than or equal to the spawn interval, spawn a note and reset the timer
            if (timeSinceLastSpawn >= spawnInterval)
            {
                SpawnNote();
                timeSinceLastSpawn = 0f;
            }
        }

    }

    // Spawn a note at a random spawn point
    void SpawnNote()
    {
            int randomNoteIndex = Random.Range(0, notes.Length);
            GameObject newNote = Instantiate(notes[randomNoteIndex], Vector3.zero, Quaternion.identity);

            // Check the tag of the note and spawn it at the corresponding spawn point
            if (newNote.CompareTag("note_1"))
            {
                newNote.transform.position = spawnPoints[0].position;
            }
            else if (newNote.CompareTag("note_2"))
            {
                newNote.transform.position = spawnPoints[1].position;
            }
            else if (newNote.CompareTag("note_3"))
            {
                newNote.transform.position = spawnPoints[2].position;
            }
            else if (newNote.CompareTag("note_4"))
            {
                newNote.transform.position = spawnPoints[3].position;
            }
    }

}
