﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip soundLeise;
    public AudioClip soundMittel;
    public AudioClip soundLaut;

    enum Lautstaerke {Leise, Mittel, Laut};

    private float onevol;
    private float stickVelocity = 0.0f;
    private Vector3 direction;
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
            other.gameObject.GetComponent<NewDrumStick>().Collided();
            stickVelocity = other.gameObject.GetComponent<NewDrumStick>().GetStickVelocity();
            //direction = other.gameObject.GetComponent<NewDrumStick>().GetDirection();


            //if (direction.y<0) { 
            Lautstaerke ls = Lautstaerke.Leise;
            if (stickVelocity<= 1)
            {
                print("Leise");
                ls = Lautstaerke.Leise;
            }
            else if(stickVelocity>1 && stickVelocity<=2.5)
            {
                print("Mittel");
                ls = Lautstaerke.Mittel ;
            } else if (stickVelocity>2.5)
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
            print("StickVelocity"+stickVelocity);
            onevol=audioSource.volume = standardvolume * stickVelocity;
            print("Volume: "+audioSource.volume);
            audioSource.PlayOneShot(soundLaut, onevol);
            print("Play");              
            }

        }

    }


//}
