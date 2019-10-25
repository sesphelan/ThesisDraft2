using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BeachTimelineController : MonoBehaviour
{

    private double lastTime;
    private PlayableDirector playableDirector;
    public GameObject controller;
    public Canvas canvas;
    public Canvas canvas2;
    public GameObject beach;

    private bool paused = false;
    // Use this for initialization
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playableDirector.time >= 17f && lastTime < 17f && !paused)
        {
            paused = true;
            playableDirector.Pause();
            controller.GetComponent<LineRendering>().enabled = true;
            controller.GetComponent<LineRenderer>().enabled = true;
        }

        if (playableDirector.time >= 19f && lastTime < 19f && !paused)
        {
            playableDirector.Pause();
            paused = true;
            controller.AddComponent<LineRenderer>();
            LineRenderer lr = controller.GetComponent<LineRenderer>();
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
            lr.material = whiteDiffuseMat;
            beach.GetComponent<SelectShape>().enabled = true;
        }

        lastTime = playableDirector.time;
        
    }

    public void playTimeline()
    {
        paused = false;
        playableDirector.Play();
    }

    public void toFinalRoom()
    {
        SceneManager.LoadScene("FinalBedroom");
    }

    public void showUI()
    {
        canvas.gameObject.SetActive(true);
    }

    public void showUI2()
    {
        canvas2.gameObject.SetActive(true);
    }


}
