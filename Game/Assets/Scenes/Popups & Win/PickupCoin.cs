using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
            PlayerMovement manager = collision.GetComponent<PlayerMovement>();
            if(manager)
            {
                manager.PickupItem();
                Destroy(gameObject);
            }
    }

}
