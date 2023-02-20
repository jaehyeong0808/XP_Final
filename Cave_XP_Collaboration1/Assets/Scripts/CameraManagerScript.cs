using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManagerScript : MonoBehaviour
{
    public Camera mainCam;
    private GameObject telposGameObj;
    private GameObject zoomObj;
    private GameObject backZoomBtn;
    private GameObject cameraDefaultPos;

    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;

        }
        else
        {
            rect.width = scalewidth;
            rect.x = (scaleheight - 1f) / 2f;
        }
        camera.rect = rect;

    }
    private void OnPreCull() => GL.Clear(true, true, Color.black);

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        telposGameObj = GameObject.Find("camera_ZoomPos");
        zoomObj = GameObject.Find("zoom_click");
        backZoomBtn = GameObject.Find("zoomBackBtn");
        backZoomBtn.SetActive(false);
        cameraDefaultPos = GameObject.Find("camera_defaultPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                //Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.tag=="telpos")
                {
                    backZoomBtn.SetActive(true);
                    zoomObj.SetActive(false);
                    mainCam.gameObject.transform.position = telposGameObj.transform.position;
                    mainCam.gameObject.transform.rotation = telposGameObj.transform.rotation;
                    Debug.Log("¼º°ø");

                }
            }
        }
    }
    public void zoomBackBtn()
    {
        zoomObj.SetActive(true);
        backZoomBtn.SetActive(false);
        mainCam.gameObject.transform.position = cameraDefaultPos.transform.position;
        mainCam.gameObject.transform.rotation = cameraDefaultPos.transform.rotation;

    }
}
