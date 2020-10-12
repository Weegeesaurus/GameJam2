using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerKeyCheck : MonoBehaviour
{
    public doorM door;
    public void Unlock()
    {
        if(door.IsLocked)
            if(PlayerState.instance.items[5] == true)
            {
                BlackoutManager bom = transform.GetComponent<BlackoutManager>();
                bom.FadeOut();
                door.IsLocked = false;
                door.Open();
                Invoke("End",2f);
            }
    }
    void End()
    {
        if(PlayerState.instance.items[9])
            SceneManager.LoadScene("GoodEnd");
        else
            SceneManager.LoadScene("BadEnd");
    }
}
