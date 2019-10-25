using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PauseTimeline : MonoBehaviour
{

    private double lastTime;
    private PlayableDirector playableDirector;
    public GameObject Andromeda;
    public GameObject Door;
    public GameObject controller;
    public GameObject bedroom;

    public Camera mainCamera;

    public Canvas canvas;
    public Canvas canvas2;

    private bool paused = false;
    private bool inColor = false;
    // Use this for initialization
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = Color.black;
        mainCamera.cullingMask = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playableDirector.time >= 142f && lastTime < 142f && !paused)
        {
            paused = true;
            playableDirector.Pause();
            Andromeda.SetActive(false);
            controller.GetComponent<LineRendering>().enabled = true;
            controller.GetComponent<LineRenderer>().enabled = true;
        }

        if (playableDirector.time >= 147f && lastTime < 147f && !paused)
        {
            playableDirector.Pause();
            paused = true;
            controller.AddComponent<LineRenderer>();
            LineRenderer lr = controller.GetComponent<LineRenderer>();
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
            lr.material = whiteDiffuseMat;
            bedroom.GetComponent<SelectShape>().enabled = true;
        }

        if (playableDirector.time >= 48f && lastTime < 48f)
        {
            mainCamera.clearFlags = CameraClearFlags.Skybox;
            mainCamera.backgroundColor = new Color(71f, 71f, 71f, 255f);
            mainCamera.cullingMask = 1;
        }

        lastTime = playableDirector.time;

    }

    public void playTimeline()
    {
        paused = false;
        playableDirector.Play();
    }

    public void toBeach()
    {
        SceneManager.LoadScene("Beach");
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
