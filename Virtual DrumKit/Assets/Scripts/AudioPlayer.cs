using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CD")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("SoundAbsch");
          
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CD")
        {
            other.gameObject.GetComponent<AudioSource>().Pause();
           
        }
    }


}