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

    private bool paused = false;
    // Use this for initialization
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playableDirector.time >= 11f && lastTime < 11f && !paused)
        {
            playableDirector.Pause();
            Andromeda.SetActive(false);
        }
    }

    public void playTimeline()
    {
        paused = true;
        playableDirector.Play();
    }

    public void toBeach()
    {
        SceneManager.LoadScene("Beach");
    }

    

}
