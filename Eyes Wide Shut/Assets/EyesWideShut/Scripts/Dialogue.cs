using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
       textcomponent.text = string.Empty;
       startDialogue(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Type each character one by one
        foreach (char c in lines[index]. ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }
}
