using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEx : MonoBehaviour
{

    public Transform target;
    public float Camdelay = 1;

    public Camera[] cameras;
    public GameObject[] postEffect;

    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        cameras[1].enabled = false;
        cameras[2].enabled = false;
        postEffect[1].SetActive(false);
        postEffect[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, target.position, Camdelay*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F1))
        {    
            
            DisableCameras();
            postEffect[0].SetActive(true);
            cameras[0].enabled = true;
            ui.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            
            DisableCameras();
            postEffect[1].SetActive(true);
            cameras[1].enabled = true;
            ui.SetActive(false);
            
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            
            DisableCameras();
            postEffect[2].SetActive(true);
            cameras[2].enabled = true;
            ui.SetActive(false);
        }

        

    }


    public void DisableCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            postEffect[i].SetActive(false);
            cameras[i].enabled = false;
        }
    }
}
