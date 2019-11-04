using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FRL.IO;

public class Drawing : MonoBehaviour
{
    public GameObject brushStroke;
    public GameObject modelObject;
    public GameObject paper;
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Canvas" && gameObject.transform.childCount > 2) {
            draw(collision);
        }
        
    }

    private void draw(Collision collision)
    {
        GameObject obj = Instantiate(brushStroke);
        obj.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        obj.transform.position = collision.contacts[0].point;
        obj.transform.position = new Vector3(obj.transform.position.x, paper.transform.position.y, obj.transform.position.z); // ensure at same height as paper

        gameObject.transform.position = obj.transform.position;

        //Renderer rend = obj.GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("_Color"); // get color of brush stroke

        //Renderer rend2 = GameObject.FindGameObjectWithTag("Drawer").GetComponent<Renderer>(); // set color as color of chalk
        //rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Canvas" && gameObject.transform.childCount > 2) {
            draw(collision);
        }
    }
}
