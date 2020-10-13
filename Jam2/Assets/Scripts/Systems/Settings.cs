using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider sensitivity;
    public Slider fov;
    public Text sensText;
    public Text fovText;
    public GameObject pauseMenu;
    private Camera cam;
    private CameraController camControl;
    public bool cursorLock;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "MainLevel")
        {
            Cursor.lockState = CursorLockMode.Locked;
            cursorLock = true;
            cam = Camera.main;
            camControl = cam.GetComponent<CameraController>();
            UpdateSensitivity();
            UpdateFov();
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "MainLevel")
            {
                if (pauseMenu.activeInHierarchy == false)   //if not paused
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }

        }
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
    public void Resume()
    {
       if (pauseMenu.activeInHierarchy==true)
        {
            if (cursorLock == true)    //recalls cursorLock
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }

            pauseMenu.SetActive(false);
            TimeState.instance.StartTime();
            PlayerState.instance.paused = false;
        }
    }
    public void Pause()
    {
        if (pauseMenu.activeInHierarchy == false)
        {
            if (Cursor.lockState == CursorLockMode.None)    //remembers cursorLocking
            {
                cursorLock = false;
            }
            else
            {
                cursorLock = true;
            }
            Cursor.lockState = CursorLockMode.None;

            pauseMenu.SetActive(true);
            TimeState.instance.StopTime();
            PlayerState.instance.paused = true;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
