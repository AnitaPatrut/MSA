using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 10f;

    private FixedJoystick joystick;

    private PlayerAnimation anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        anim = GetComponent<PlayerAnimation>();

        GameObject.Find("Jump button").GetComponent<Button>().onClick.AddListener(PlayerJump);
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector3(joystick.Horizontal * moveForce,
                                      myBody.velocity.y,
                                      joystick.Vertical * moveForce);

        if(joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            anim.Walk(true);

            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
        else
        {
            anim.Walk(false);
        }
    }

    public void PlayerJump()
    {
        anim.Jump();
    }
}
