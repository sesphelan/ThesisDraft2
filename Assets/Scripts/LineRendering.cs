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
                if (hit.transform.gameObject.layer == 5) { // IF IT HITS A UI BUTTON 
                    turnRed(hit.transform.gameObject.GetComponent<Button>());
                }

            }
            else {
                GameObject[] buttons = new GameObject[4];
                buttons[0] = GameObject.FindGameObjectWithTag("chooseCube");
                buttons[1] = GameObject.FindGameObjectWithTag("chooseSphere");
                buttons[2] = GameObject.FindGameObjectWithTag("choosePink");
                buttons[3] = GameObject.FindGameObjectWithTag("chooseBlue");

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
