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
    public GameObject sizeCanvas;

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
        GameObject chooseSmall = GameObject.FindGameObjectWithTag("chooseSmall");
        GameObject chooseMedium = GameObject.FindGameObjectWithTag("chooseMedium");
        GameObject chooseLarge = GameObject.FindGameObjectWithTag("chooseLarge");

        if (chooseButterfly)
        {
            if(chooseButterfly.GetComponent<Button>().colors.normalColor == Color.red)
            {
                chalk = setModel(chalk, butterfly);
            }
            else if(chooseGuitar.GetComponent<Button>().colors.normalColor == Color.red)
            {
                chalk = setModel(chalk, guitar);
            }

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
                // cleanUp();
                GameObject canvas = GameObject.FindGameObjectWithTag("UI");
                canvas.SetActive(false);

                sizeCanvas.SetActive(true);
            }
            if (chooseRide)
            {
                chalk = setModel(chalk, ride);
                cleanUp();
            }

            if (chooseSmall)
            {
                if (chooseSmall.GetComponent<Button>().colors.normalColor == Color.red) // small
                {
                    chalk.GetComponent<PickUppable>().scale = 0.5f;
                }
                else if (chooseMedium.GetComponent<Button>().colors.normalColor == Color.red) // medium
                {
                    chalk.GetComponent<PickUppable>().scale = 1f;
                }
                else // large
                {
                    chalk.GetComponent<PickUppable>().scale = 5f;
                }
                cleanUp();
            }

        }
    }
}
