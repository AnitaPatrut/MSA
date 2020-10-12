using System.Collections;
using UnityEngine;

public class Timmy_Controls : MonoBehaviour
{
    static Animator anim;
    public float speed = 1.20F;
    public float rotationSpeed = 70.0F;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        if (!Input.GetButtonDown("Jump"))
        {
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
        

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }

        if(translation != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
