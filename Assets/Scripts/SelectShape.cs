using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;
using UnityEngine.UI;

public class SelectShape : MonoBehaviour, IPointerTriggerPressDownHandler {
    // Start is called before the first frame update
    public GameObject sphere;
    public GameObject cube;
    public GameObject circle;
    public GameObject square;

    private static bool objectSelected = false;

    private static bool drawCircle = false;

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

    private GameObject changeParams(GameObject obj, string tag, string color)
    {
        obj.GetComponentInChildren<Text>().text = color;
        obj.tag = tag;
        obj.name = tag;
        return obj;
    }

    private Renderer chooseColor(Renderer rend, string color)
    {
        Color col;
        if(color == "pink") {
            col = Color.magenta;
            rend.material.SetColor("_Color", col);
        }
        else {
            col = Color.blue;
            rend.material.SetColor("_Color", col);
        }
        return rend;
    }

    private void cleanUp()
    {
        GameObject obj1 = GameObject.FindGameObjectWithTag("chooseBlue");
        GameObject obj2 = GameObject.FindGameObjectWithTag("choosePink");
        obj1.SetActive(false);
        obj2.SetActive(false);

        GameObject leftController = GameObject.FindGameObjectWithTag("leftController");
        leftController.GetComponent<LineRenderer>().enabled = false;

        GameObject controller = GameObject.FindGameObjectWithTag("Controller");
        controller.GetComponent<Drawing>().enabled = true;

        gameObject.GetComponent<SelectShape>().enabled = false;

        LineRenderer lr= GameObject.FindGameObjectWithTag("leftController").GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    public void OnPointerTriggerPressDown(XREventData eventData)
    {
        GameObject chalk = GameObject.FindGameObjectWithTag("Drawer");
        if (objectSelected == false) { // CHOOSE TYPE OF SHAPE TO DRAW FIRST
            print("hi");
            print(objectSelected);
            if (gameObject.tag == "chooseSphere") {
                print("Chosen Sphere");
                chalk = setModel(chalk, sphere);
                drawCircle = true;
            }
            else if (gameObject.tag == "chooseCube") {
                print("Chosen Cube");
                chalk = setModel(chalk, cube);
            }

            GameObject obj1 = GameObject.FindGameObjectWithTag("chooseSphere");
            GameObject obj2 = GameObject.FindGameObjectWithTag("chooseCube");
            obj1 = changeParams(obj1, "chooseBlue", "Blue");
            obj2 = changeParams(obj2, "choosePink", "Pink");
            objectSelected = true;
        }
        else { // THEN CHOOSE COLOR OF SHAPE
            Renderer chalkRender = chalk.AddComponent<MeshRenderer>();
            if (gameObject.tag == "choosePink") {
                print("Chosen pink");
                chalkRender = chooseColor(chalkRender, "pink");
            }
            else if (gameObject.tag == "chooseBlue") {
                print("Chosen blue");
                chalkRender = chooseColor(chalkRender, "blue");
            }

            if (drawCircle)
                Instantiate(circle);
            else
                Instantiate(square);

            cleanUp();
            this.enabled = false;
            
        }
    }
}
