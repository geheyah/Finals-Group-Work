using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScrollerScript : MonoBehaviour
{

    public bool hasStarted;
    public float noteSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            transform.Translate(0f, -noteSpeed * Time.deltaTime, 0f);
        }
    }
}
