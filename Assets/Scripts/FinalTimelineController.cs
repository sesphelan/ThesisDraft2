using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FinalTimelineController : MonoBehaviour
{
    private PlayableDirector playableDirector;
    private double lastTime;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = Color.white;
        mainCamera.cullingMask = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playableDirector.time >= 2f && lastTime < 2f)
        {
            mainCamera.clearFlags = CameraClearFlags.Skybox;
            mainCamera.backgroundColor = new Color(71f, 71f, 71f, 255f);
            mainCamera.cullingMask = 1;
        }
        if(playableDirector.time >= 14f && lastTime < 14f)
        {
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
            mainCamera.backgroundColor = Color.black;
            mainCamera.cullingMask = 0;
        }
        lastTime = playableDirector.time;
    }
}
