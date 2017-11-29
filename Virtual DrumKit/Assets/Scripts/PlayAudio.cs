using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioclip;
    private float stickVelocity = 0.0f;
    private AudioSource audio;
    float standardvolume;
    // Use this for initialization
    void Start()
    {

        audio = GetComponent<AudioSource>();
        standardvolume = audio.volume;
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
            audio.volume = standardvolume * stickVelocity;
            audio.Play();
            //audio.volume = standardvolume;

        }

    }
}
