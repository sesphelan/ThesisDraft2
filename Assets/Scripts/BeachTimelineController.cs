using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BeachTimelineController : MonoBehaviour
{

    private double lastTime;
    private PlayableDirector playableDirector;

    private bool paused = false;
    // Use this for initialization
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (playableDirector.time >= 8f && lastTime < 8f && !paused)
        {
            playableDirector.Pause();
        }
        */
    }

    public void playTimeline()
    {
        paused = true;
        playableDirector.Play();
    }

    public void toFinalRoom()
    {
        SceneManager.LoadScene("FinalBedroom");
    }



}
