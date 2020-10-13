using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string code;
    public bool powerPD;
    public bool active;
    private string entered;
    public doorM door;
    public Image statusLight;
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        entered = "";
    }

    public void AddNum(string num)
    {
        if (entered.Length<4)
        {
            entered += num;
            displayText.text = entered;
        }
    }

    public void EnterCode()
    {
        if (entered == code)
        {
            door.IsLocked = false;
            StartCoroutine(Visual(true));
        }
        else 
        {
            StartCoroutine(Visual(false));
        }
    }
    IEnumerator Visual(bool correct)
    {
        if (correct)
        {
            statusLight.color = Color.green;
            yield return new WaitForSeconds(1.5f);
            PlayerState.instance.busy = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject obj = Instantiate(PlayerState.instance.SuccessSound);
            Destroy(obj, 5f);
            Destroy(gameObject);
        }
        else
        {
            statusLight.color = Color.red;
            yield return new WaitForSeconds(.2f);
            statusLight.color = Color.black;
            yield return new WaitForSeconds(.2f);
            statusLight.color = Color.red;
            yield return new WaitForSeconds(1.1f);
            PlayerState.instance.busy = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject obj = Instantiate(PlayerState.instance.ErrorSound);
            Destroy(obj, 5f);
            Destroy(gameObject);
        }
    }
}
