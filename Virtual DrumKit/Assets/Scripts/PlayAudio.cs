using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip soundLeise;
    public AudioClip soundMittel;
    public AudioClip soundLaut;

    enum Lautstaerke {Leise, Mittel, Laut};

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
            Vector3 direction = other.transform.position - transform.position;

            if (Vector3.Dot(transform.forward, direction) > 0)
            {
                print("Back");
            }
            if (Vector3.Dot(transform.forward, direction) < 0)
            {
                print("Front");
            }
            if (Vector3.Dot(transform.forward, direction) == 0)
            {
                print("Side");
            }

            print("Stick hit");

            other.gameObject.GetComponent<Drumstick>().Collided();
            stickVelocity = other.gameObject.GetComponent<Drumstick>().GetStickVelocity();

            Lautstaerke ls = Lautstaerke.Leise;
            if (stickVelocity<= 1)
            {
                print("Leise");
                ls = Lautstaerke.Leise;
            }
            else if(stickVelocity>1 && stickVelocity<=4)
            {
                print("Mittel");
                ls = Lautstaerke.Mittel ;
            } else if (stickVelocity>4)
            {
                print("Laut");
                ls = Lautstaerke.Laut;
            }

            switch (ls)
            {
                case Lautstaerke.Laut:
                    audioSource.clip = soundLaut;
                    print("Laut Clip");
                    break;

                case Lautstaerke.Mittel:
                    print("Mittel Clip");
                    audioSource.clip = soundMittel;
                    break;

                case Lautstaerke.Leise:
                    print("Leise Clip");
                    audioSource.clip = soundLeise;
                    break;

            }
            audioSource.volume = standardvolume * stickVelocity;
            audioSource.Play();
            print("Play");
            //audio.volume = standardvolume;

        }

    }


}
