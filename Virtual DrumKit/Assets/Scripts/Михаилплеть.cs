using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Михаилплеть : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CD")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
          
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