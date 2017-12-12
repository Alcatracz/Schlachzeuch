using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BaseClave : MonoBehaviour {

    private float hitVelocity = 0.0f;
    private AudioSource audioSource;
    float standardvolume = 1.0f;
    private Hand hand;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //standardvolume = audioSource.volume;
    }

    void OnAttachedToHand(Hand hand)
    {
        this.hand = hand;
        print("Attached");
    }

    void OnDetachedFromHand(Hand hand)
    {
        print("Detached");
        this.hand = null;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Claves")
        {
            other.gameObject.GetComponent<HitClave>().Collided();
            hitVelocity = other.gameObject.GetComponent<HitClave>().GetStickVelocity();
            print("HitVelocity: "+hitVelocity);
            print("StandardVolume: "+standardvolume);
            audioSource.volume = standardvolume * hitVelocity;
            print("Volume: "+audioSource.volume);
            audioSource.Play();
            hand.controller.TriggerHapticPulse(400);
            hand.otherHand.controller.TriggerHapticPulse(400);
        }

    }
}
