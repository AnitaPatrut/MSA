using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject obj;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            obj.SetActive(true);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(false);
        }
    }
}
