using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;

public class ColorPickerWheel : MonoBehaviour, IGlobalTouchpadPressDownHandler, IGlobalTouchpadPressUpHandler
{

    public GameObject colorModel;
    public GameObject blackwheel;

    private float hue, stauration, value = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGlobalTouchpadPressDown(XREventData eventData)
    {

    }

    public void OnGlobalTouchpadPressUp(XREventData eventData)
    {

    }
}
