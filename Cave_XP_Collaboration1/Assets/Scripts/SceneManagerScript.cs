using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private Camera currentCamera;
    private Transform[] cameraPosition = new Transform[2];

    int i;
    RaycastHit hit;

    void Start()
    {
        i = 1;
        currentCamera = GameObject.Find("Camera").GetComponent<Camera>();
        if (SceneManager.GetActiveScene().name == "Scene1_ControllRoom")
        {
            cameraPosition[0] = GameObject.Find("CameraPosition0").transform;
            cameraPosition[1] = GameObject.Find("CameraPosition1").transform;
        }
    }

    private void Update()
    {
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (hit.collider.gameObject.CompareTag("ToSetting"))
            {
                SceneManager.LoadScene("Scene2_SettingRoom");
            }
            else if (hit.collider.gameObject.tag == "MonsterRoomDoor")
            {
                currentCamera.transform.position = cameraPosition[i % 2].position;
                currentCamera.transform.rotation = cameraPosition[i % 2].rotation;
                i++;
            }
            else if (hit.collider.gameObject.CompareTag("ToWare"))
            {
                SceneManager.LoadScene("Scene3_WareHouse");
            }
            /*else if (gameObject.CompareTag("ToControl"))
            {
                SceneManager.LoadScene("Controll_monstor_room");
            }*/
            else if (hit.collider.gameObject.CompareTag("Puzzle1"))
            {
                SceneManager.LoadScene("Mini1_WireGame");
            }
            else if (hit.collider.gameObject.CompareTag("Puzzle2"))
            {
                SceneManager.LoadScene("Mini2_MemoryGame");
            }
            else if (hit.collider.gameObject.CompareTag("Puzzle3"))
            {
                SceneManager.LoadScene("Mini3_AnagramGame");
            }
        }
    }


}



