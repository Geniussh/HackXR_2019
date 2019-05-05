using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vision.VisionEffect.ColorBlind;

[RequireComponent(typeof(Camera))]
public class IntensityDown : MonoBehaviour
{
    // float intensity : ;
    [SerializeField] private VisionSimulator vs;

    public IntensityHandler handler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        print("Collider entered " + handler.intensity);
        if (handler.intensity > 0.0f)
        {
            handler.intensity -= 0.01f;
            vs.Slider_Changed(handler.intensity);
        }
        //Mathf.Clamp01(intensity + 0.01f)
    }
}
