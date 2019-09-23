using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;


public class CreateObject : MonoBehaviour, IPointerTriggerPressDownHandler {
    // Start is called before the first frame update
    public GameObject modelObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerTriggerPressDown(XREventData eventData)
    {
        
        if(GameObject.FindGameObjectsWithTag("brushStroke").Length > 0) {

             GameObject chalk = GameObject.FindGameObjectWithTag("Drawer");
             Renderer rend2 = chalk.GetComponent<Renderer>(); 

             GameObject[] allObjects = GameObject.FindGameObjectsWithTag("brushStroke");
             for (int i = 0; i < allObjects.Length; i++)
                 Destroy(allObjects[i]);
             GameObject obj = Instantiate(modelObject);

             Renderer rend = obj.GetComponent<Renderer>();
             rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));
         }
         

    }
}
