using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGlass : Interactable
{
    [SerializeField]
    private AudioSource eyeGlassintro;

    public GameObject dialogue05;
    public GameObject EyeGlassPanel;

    void Start()
    {
        eyeGlassintro = eyeGlassintro.GetComponent<AudioSource>();
    }
    
    protected override void Interact()
    {
        EyeGlassPanel.SetActive(true);
        dialogue05.SetActive(false);

        eyeGlassintro.Play();

    }
}
