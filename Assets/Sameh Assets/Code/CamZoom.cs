using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    private Camera Cam;

    public float ZoomSpeed;
    public KeyCode Zbutton;

    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(Zbutton))
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4, Time.deltaTime * ZoomSpeed);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 6, Time.deltaTime * ZoomSpeed);
        }
    }
}
