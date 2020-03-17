using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    // Start is called before the first frame update
    void Start()
    {
        dBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogActive = false;
        } 
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dText.text = dialogue;
        dBox.SetActive(true);
        
    }
}
