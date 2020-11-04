using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour
{
    Animator anim;
   
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Turning();
        Move();
    }

    void Turning()
    {
        anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    void Move()
    {
        anim.SetFloat("isWalking", Input.GetAxis("Vertical"));
    }
}
