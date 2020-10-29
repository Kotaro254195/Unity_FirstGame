using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_animation : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            anim.SetBool("Walk", true);
            transform.position += transform.forward * 0.2f;
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Jump",true);
        }
        else
        {
            anim.SetBool("Jump",false);
        }


        if (Input.GetKey("right")) {
            transform.Rotate(0, 2, 0);
        }
        if (Input.GetKey ("left")) {
            transform.Rotate(0, -2, 0);
        }
    }
}
