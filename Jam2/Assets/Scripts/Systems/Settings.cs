using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider sensitivity;
    public Slider fov;
    public Text sensText;
    public Text fovText;
    private Camera cam;
    private CameraController camControl;

    void Start()
    {
        cam = Camera.main;
        camControl = cam.GetComponent<CameraController>();
        sensText.text = Mathf.Round(sensitivity.value * 100f).ToString();
        fovText.text = cam.fieldOfView.ToString();
    }

    public void UpdateSensitivity()
    {
        sensitivity.value = Mathf.Round(sensitivity.value * 100f) / 100f;
        camControl.sensitivity = 300f + sensitivity.value * 400f;
        sensText.text = Mathf.Round(sensitivity.value * 100f).ToString();
    }
    public void UpdateFov()
    {
        fov.value= Mathf.Round(fov.value * 100f) / 100f;
        cam.fieldOfView = 60f+fov.value*40f;
        fovText.text = Mathf.Round(cam.fieldOfView).ToString();
    }
}
