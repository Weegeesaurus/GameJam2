using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] public string scene;
    // Start is called before the first frame update

    public void startButton()
    {
        SceneManager.LoadScene(scene);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
