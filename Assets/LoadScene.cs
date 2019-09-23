using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    void changeText()
    {
        Text txt = gameObject.GetComponent<Text>();
        txt.text = "Changed!";
    }*/

    void LoadNewScene()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Table");
    }
}
