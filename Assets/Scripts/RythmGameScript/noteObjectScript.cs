using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObjectScript : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                Destroy(this.gameObject);

                RythmGameManager.instance.noteHit();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
            Debug.Log("can be press");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            RythmGameManager.instance.noteMissed();
        }
    }
}
