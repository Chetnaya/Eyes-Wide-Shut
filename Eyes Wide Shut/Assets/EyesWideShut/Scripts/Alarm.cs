using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    // The player object
    public Transform player;
    // The audio source for the alarm
    public AudioSource audioSource;
    // The time it takes for the alarm sound to fade in or out
    public float fadeTime = 2.0f;
    // The maximum distance at which the alarm can be heard
    private float maxDistance;
    //Rotation Speed
    public float speed = 10.0f; 
    //main Volume
    public float overallVolume = 1.0f;
    
    void Start()
    {
        // Initialize the maxDistance variable
        maxDistance = audioSource.maxDistance;
    }

    void Update()
    {
         // Distance between the alarm object and the player
        float distance = Vector3.Distance(transform.position, player.position);
        //The volume of the alarm sound based on the distance from the player
        float volume = Mathf.InverseLerp(maxDistance, 0.0f, distance);
        // Smoothly adjust the volume of the alarm sound based on the fade time
        audioSource.volume = Mathf.Lerp(audioSource.volume, volume * overallVolume, Time.deltaTime * fadeTime);
        // Rotate the cylinder around its center
        transform.Rotate(Vector3.forward *  speed * Time.deltaTime);
    }
}
