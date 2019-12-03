using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendering : MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {

    }

    private void turnRed(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 100, 100, 255);
        button.colors = colors;
    }

    private void turnWhite(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(255, 255, 255, 255);
        button.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        if(lr.enabled == true) {
            lr.SetPosition(0, gameObject.transform.position);
            lr.SetPosition(1, gameObject.transform.forward * -20 + transform.position);

            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, (gameObject.transform.forward * -20 + transform.position) - gameObject.transform.position, out hit)) {
                if (hit.transform.gameObject.tag == "chooseButterfly" || hit.transform.gameObject.tag == "chooseGuitar" || hit.transform.gameObject.tag == "chooseBeach" || hit.transform.gameObject.tag == "chooseDog" || hit.transform.gameObject.tag == "chooseRide" || hit.transform.gameObject.tag == "chooseSmall" || hit.transform.gameObject.tag == "chooseMedium" || hit.transform.gameObject.tag == "chooseLarge") { // IF IT HITS A UI BUTTON 
                    if (hit.transform.gameObject.tag == "chooseButterfly")
                    {
                        turnRed(GameObject.FindGameObjectWithTag("chooseButterfly").GetComponent<Button>());
                        turnWhite(GameObject.FindGameObjectWithTag("chooseGuitar").GetComponent<Button>());
                    }
                    else if (hit.transform.gameObject.tag == "chooseGuitar")
                    {
                        turnRed(GameObject.FindGameObjectWithTag("chooseGuitar").GetComponent<Button>());
                        turnWhite(GameObject.FindGameObjectWithTag("chooseButterfly").GetComponent<Button>());
                    }
                    else
                    {
                        string tag = hit.transform.gameObject.tag;
                        turnRed(GameObject.FindGameObjectWithTag(hit.transform.gameObject.tag).GetComponent<Button>());
                        Button[] buttons = GameObject.FindObjectsOfType<Button>();
                        foreach(Button button in buttons)
                        {
                            if (button.transform.gameObject.tag != tag)
                                turnWhite(button);
                        }
                    }
                }

            }
            else {
                GameObject[] buttons = new GameObject[8];
                buttons[0] = GameObject.FindGameObjectWithTag("chooseButterfly");
                buttons[1] = GameObject.FindGameObjectWithTag("chooseGuitar");
                buttons[2] = GameObject.FindGameObjectWithTag("chooseBeach");
                buttons[3] = GameObject.FindGameObjectWithTag("chooseDog");
                buttons[4] = GameObject.FindGameObjectWithTag("chooseRide");
                buttons[5] = GameObject.FindGameObjectWithTag("chooseSmall");
                buttons[6] = GameObject.FindGameObjectWithTag("chooseMedium");
                buttons[7] = GameObject.FindGameObjectWithTag("chooseLarge");

                for (int i = 0; i < buttons.Length; i++) {
                    GameObject button = buttons[i];
                    if (button != null) {
                        turnWhite(button.GetComponent<Button>());
                    }
                }

            }
        }
    }
}
