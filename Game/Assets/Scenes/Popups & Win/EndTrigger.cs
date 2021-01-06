using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject obj;
    void OnTriggerEnter(Collider collision)
    {
        PlayerMovement plr = collision.GetComponent<PlayerMovement>();
        if(plr.coinCount >= 3)
            gameManager.CompleteLevel();
        else
        {
            obj.SetActive(true);
   
        }
    }

    void OnTriggerExit(Collider collision)
    {
        obj.SetActive(false);
    }
}
