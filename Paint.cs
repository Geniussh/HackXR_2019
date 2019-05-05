using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    //public GameObject paintTemp;
    public GameObject[] paintTemps;
    public int paintNum = 0;


    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)!=0f)
        {
            paintNum = 0;
            PaintOnce();
        }

        else if (OVRInput.Get(OVRInput.Button.Two))
        {
            paintNum = 1;
            PaintOnce();
        }

        else if (OVRInput.Get(OVRInput.Button.One))
        {
            paintNum = 2;
            PaintOnce();
        }


    }
    
    void PaintOnce()
    {
        print("Enter PaintOnce");
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5.0f);
        GameObject paint = (GameObject)Instantiate(paintTemps[paintNum], transform.position, transform.rotation);
        Destroy(paint, 20);
    }
}
