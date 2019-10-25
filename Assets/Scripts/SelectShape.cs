using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;
using UnityEngine.UI;

public class SelectShape : MonoBehaviour, IGlobalTriggerPressDownHandler {
    // Start is called before the first frame update
    public GameObject butterfly;
    public GameObject guitar;
    public GameObject beach;
    public GameObject controllerModel;
    public GameObject dog;
    public GameObject ride;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject setModel(GameObject chalk, GameObject shape)
    {
        chalk.GetComponent<PickUppable>().modelObject = shape;
        return chalk;
    } 


    private void cleanUp()
    {
        /*
        GameObject obj1 = GameObject.FindGameObjectWithTag("chooseButterfly");
        GameObject obj2 = GameObject.FindGameObjectWithTag("chooseGuitar");
        obj1.SetActive(false);
        obj2.SetActive(false);

        GameObject controller = GameObject.FindGameObjectWithTag("Controller");
        controller.GetComponent<Drawing>().enabled = true;

        gameObject.GetComponent<SelectShape>().enabled = false;
        */

        GameObject canvas = GameObject.FindGameObjectWithTag("UI");
        canvas.SetActive(false);

        GameObject controller = GameObject.FindGameObjectWithTag("Controller");
        controller.GetComponent<Drawing>().enabled = true;

        gameObject.GetComponent<SelectShape>().enabled = false;

        // Destroy(controllerModel.GetComponent<LineRendering>());
        Destroy(controllerModel.GetComponent<LineRenderer>());

        //controllerModel.GetComponent<LineRendering>().enabled = false;
        //controllerModel.GetComponent<LineRenderer>().enabled = false;

    }

    public void OnGlobalTriggerPressDown(XREventData eventData)
    {
        GameObject chalk = GameObject.FindGameObjectWithTag("Drawer");
        GameObject chooseButterfly = GameObject.FindGameObjectWithTag("chooseButterfly");
        GameObject chooseGuitar = GameObject.FindGameObjectWithTag("chooseGuitar");
        GameObject chooseBeach = GameObject.FindGameObjectWithTag("chooseBeach");
        GameObject chooseDog = GameObject.FindGameObjectWithTag("chooseDog");
        GameObject chooseRide = GameObject.FindGameObjectWithTag("chooseRide");

        if (chooseButterfly)
        {
            if(chooseButterfly.GetComponent<Button>().colors.normalColor == Color.red)
                chalk = setModel(chalk, butterfly);
            else if(chooseGuitar.GetComponent<Button>().colors.normalColor == Color.red)
                chalk = setModel(chalk, guitar);
            cleanUp();
        }
        else
        {
            if (chooseBeach)
            {
                chalk = setModel(chalk, beach);
                cleanUp();
            }
            if (chooseDog)
            {
                chalk = setModel(chalk, dog);
                cleanUp();
            }
            if (chooseRide)
            {
                chalk = setModel(chalk, ride);
                cleanUp();
            }

        }
    }
}
