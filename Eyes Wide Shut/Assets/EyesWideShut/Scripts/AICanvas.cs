using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICanvas : MonoBehaviour
{
    public GameObject WelcomeMessage;
    public GameObject Hud;
    public GameObject NextButton;
    public GameObject OkButton;
    public GameObject AISpeech1;
    public GameObject arrow;

    public void Button01()
    {
        WelcomeMessage.SetActive(false);
        Hud.SetActive(false);
        NextButton.SetActive(false);

        OkButton.SetActive(true);
        AISpeech1.SetActive(true);     

        //AI speech audio active
    }

    public void Button02()
    {
        arrow.SetActive(true);
        AISpeech1.SetActive(false);
        OkButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
