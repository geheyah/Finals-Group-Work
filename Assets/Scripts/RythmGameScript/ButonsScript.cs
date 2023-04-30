using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonsScript : MonoBehaviour
{
    private MeshRenderer theSr;
    public Material defaultImage;
    public Material pressedImage;

    public KeyCode KeyToPress;

    // Start is called before the first frame update
    void Start()
    {
        theSr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            theSr.material = pressedImage;
        }
        if(Input.GetKeyUp(KeyToPress))
        {
            theSr.material = defaultImage;
        }
    }

}
