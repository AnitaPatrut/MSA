using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 20f;
    public bool grabbed;
    private FixedJoystick joystick;
    private PlayerAnimation anim;

    public Inventory inventory;

    public HUD Hud;


    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        anim = GetComponent<PlayerAnimation>();

        GameObject.Find("Jump button").GetComponent<Button>().onClick.AddListener(PlayerJump);
        GameObject.Find("Grab button").GetComponent<Button>().onClick.AddListener(GrabItem);
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

    private IInventoryItem mItemToPick = null;

    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            // inventory.AddItem(item);
            mItemToPick = item;
            Hud.OpenMessagePanel("");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            // inventory.AddItem(item);
            mItemToPick = null;
            Hud.CloseMessagePanel();
        }
    }

    public void GrabItem()
    {
        inventory.AddItem(mItemToPick);
        mItemToPick.OnPickup();
        Hud.CloseMessagePanel();
    }
}
