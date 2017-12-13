using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioclip;
    private float stickVelocity = 0.0f;
    private AudioSource audioSource;
    float standardvolume= 1.0f;
    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        //standardvolume = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stick")
        {

            other.gameObject.GetComponent<Drumstick>().Collided();
            stickVelocity = other.gameObject.GetComponent<Drumstick>().GetStickVelocity();
            audioSource.volume = standardvolume * stickVelocity;
            audioSource.Play();
            //audio.volume = standardvolume;

        }

    }
}
