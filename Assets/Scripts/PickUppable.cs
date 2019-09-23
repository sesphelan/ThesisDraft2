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

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = paper.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if(grip == true) {
            FixedJoint fx = XRController.GetComponent<FixedJoint>();
            gameObject.transform.position = fx.transform.position;
            gameObject.transform.rotation = fx.transform.rotation;
        }
        */
        
    }

    public void OnPointerTriggerPressDown(XREventData eventData)
    {
        //This will only be called when the object is being pointed at by a controller.
        //print("trigger");
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

                anim.Play("Paper");
                anim.Play("Paper");
                anim.Play("Paper");

                if (modelObject.tag != "Scene")
                {
                    GameObject obj = Instantiate(modelObject);
                    Renderer rend = obj.GetComponent<Renderer>();
                    rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));
                }
                else
                {
                    timeline.GetComponent<PauseTimeline>().playTimeline();
                }
          
            }
        }
    }
    
    public void pickUp()
    {

        Debug.Log("pick up");
        gameObject.transform.SetParent(XRController.transform);
        XRController.transform.GetChild(0).GetComponent<Collider>().enabled = false;

        //Renderer doorRenderer = door.GetComponent<Renderer>();
        //doorRenderer.material.color = Color.white;

        
        /*
        FixedJoint fx = XRController.gameObject.AddComponent<FixedJoint>();
        
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        fx.connectedBody = rb;
        */
    }

    public void release()
    {
        
        gameObject.transform.SetParent(bedroom.transform);
        XRController.transform.GetChild(0).GetComponent<Collider>().enabled = true;
        /*
        if (XRController.gameObject.GetComponent<FixedJoint>()) {
            FixedJoint fx = XRController.gameObject.GetComponent<FixedJoint>();
            fx.connectedBody = null;
            Destroy(fx);
        }
        */

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
