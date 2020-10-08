using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour
{
    [TextArea]
    public string dialogue;
    private Text txt;
    private int pos=0;
    public float scrollSpeed;
    private float timer=0f;
    private GameObject owner = null;
    // Start is called before the first frame update
    void Start()
    {
        txt = transform.Find("Text").GetComponent<Text>();
    }
    public void SetOwner(GameObject obj)
    {
        owner = obj;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime*scrollSpeed;
        if (timer>=1 && pos<dialogue.Length)
        {
            timer = 0f;
            pos++;
            UpdateText();
        }
        if (pos >= dialogue.Length)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (owner!=null)
                {
                    owner.GetComponent<DialogueChain>().Done();
                }
                Destroy(gameObject);
            }
        }
    }
    void UpdateText()
    {
        txt.text = dialogue.Substring(0,pos);
    }
}
