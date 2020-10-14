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
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKey("down"))
        {
            anim.SetBool("Jump",true);
        }
        else
        {
            anim.SetBool("Jump",false);
        }
    }
}
