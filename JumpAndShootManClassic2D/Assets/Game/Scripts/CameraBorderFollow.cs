using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderFollow : MonoBehaviour {
    public string cameraSide;
    public GameObject camera;
    public float cameraSpeed = 4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Camera Collider Player");
            if (cameraSide == "Left")
            {
                camera.transform.Translate(Vector2.left * cameraSpeed * Time.deltaTime);
                Debug.Log("Camera Left");
                //gameobject.transform.position.x = gameobject.transform.position.x + 0.01f;
            }
            else if (cameraSide == "Right")
            {
                camera.transform.Translate(Vector2.right * cameraSpeed * Time.deltaTime);
                Debug.Log("Camera Right");
            }
            else if (cameraSide == "Bottom")
            {
                camera.transform.Translate(Vector2.down * cameraSpeed * Time.deltaTime);
                Debug.Log("Camera Bottom");
            }
            else if (cameraSide == "Top")
            {
                camera.transform.Translate(Vector2.up * cameraSpeed * Time.deltaTime);
                Debug.Log("Camera Top");
            }
            else
            {
                Debug.Log("Camera side isn't Right or Left or Top or Bottom?");
            }
        }
    }
}
