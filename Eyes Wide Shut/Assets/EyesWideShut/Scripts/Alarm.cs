using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public Transform player;
    public AudioSource audioSource;
    public float fadeTime = 2.0f;

    private float maxDistance;

    public float speed = 10.0f; // adjust the speed of rotation

    void Start()
    {
        maxDistance = audioSource.maxDistance;
    }

    void Update()
    {
        //Audio Setting
        float distance = Vector3.Distance(transform.position, player.position);
        float volume = Mathf.InverseLerp(maxDistance, 0.0f, distance);
        audioSource.volume = Mathf.Lerp(audioSource.volume, volume, Time.deltaTime * fadeTime);

        // Rotate the cylinder around its center
        transform.Rotate(Vector3.forward *  speed * Time.deltaTime);
    }
}
