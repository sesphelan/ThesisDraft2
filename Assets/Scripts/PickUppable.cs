using FRL.IO;
using UnityEngine;

public class PickUppable : MonoBehaviour, IPointerTriggerPressDownHandler, IPointerTriggerPressUpHandler
{

    Collision coll;
    bool grip = false;
    public FRL.XRController XRController;
    public GameObject modelObject;
    public GameObject bedroom;
    public GameObject door;
    public GameObject timeline;
    public GameObject paper;

    private Rigidbody rb;
    private Animator anim;
    private Animator modelAnim;
    private AudioSource audioData;
    private AudioSource userAudio1;
    private AudioSource userAudio2;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = paper.GetComponent<Animator>();
        AudioSource[] aSources = bedroom.GetComponents<AudioSource>();
        userAudio1 = aSources[0];
        userAudio2 = aSources[1];
        audioData = timeline.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void OnPointerTriggerPressDown(XREventData eventData)
    {
        if(coll != null) {
            if(grip == false) {
                grip = true;
                pickUp();
            }
        }
    }

    public void OnPointerTriggerPressUp(XREventData eventData)
    {
        if(grip == true) {
            grip = false;
            coll = null;
            release();
            if (GameObject.FindGameObjectsWithTag("brushStroke").Length > 0) {

                GameObject chalk = GameObject.FindGameObjectWithTag("Drawer");
                Renderer rend2 = chalk.GetComponent<Renderer>();

                GameObject[] allObjects = GameObject.FindGameObjectsWithTag("brushStroke");
                for (int i = 0; i < allObjects.Length; i++)
                    Destroy(allObjects[i]);

                if(timeline.tag != "BeachTimeline")
                    anim.Play("Paper");


                if (modelObject.tag != "Scene")
                {
                    GameObject obj = Instantiate(modelObject);
                    if(modelObject.tag == "guitar")
                    {
                        audioData.Play();
                        userAudio2.Play();
                    }
                    else if(modelObject.tag == "butterfly")
                    {
                        userAudio1.Play();
                    }
                    else if(modelObject.tag == "ride")
                    {
                        userAudio1.Play();
                    }
                    else
                    {
                        audioData.Play();
                        userAudio2.Play();
                    }
                    if(timeline.tag != "BeachTimeline")
                        timeline.GetComponent<PauseTimeline>().playTimeline();
                    else
                        timeline.GetComponent<BeachTimelineController>().playTimeline();
                }
                else
                {
                    if(timeline.tag != "BeachTimeline")
                    {
                        timeline.GetComponent<PauseTimeline>().playTimeline();
                    }
                    else
                    {
                        timeline.GetComponent<BeachTimelineController>().playTimeline();
                    }
                }
          
            }
        }
    }
    
    public void pickUp()
    {

        Debug.Log("pick up");
        gameObject.transform.SetParent(XRController.transform);
        //XRController.transform.GetChild(0).GetComponent<Collider>().enabled = false;
        GameObject controller = GameObject.FindGameObjectWithTag("Finish");
        controller.GetComponent<Collider>().enabled = false;

    }

    public void release()
    {
        
        gameObject.transform.SetParent(bedroom.transform);
        // XRController.transform.GetChild(0).GetComponent<Collider>().enabled = true;
        GameObject controller = GameObject.FindGameObjectWithTag("Finish");
        controller.GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Controller") {
            coll = collision;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Controller") {
            coll = null;
        }
    }

}
