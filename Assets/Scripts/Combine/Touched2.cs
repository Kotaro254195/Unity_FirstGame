using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Touched2 : MonoBehaviour
{
    public MoveAndRoll mar;
    void Start()
    {
        mar=GameObject.Find("MoveAndRoll_Controller").GetComponent<MoveAndRoll>();
    }
    public void Touch()
    {
        Debug.Log(this.transform.parent.name);
        mar.setobj=GameObject.Find(this.transform.parent.name.Substring(7)).gameObject;

        // GameObject[] objs=GameObject.FindGameObjectsWithTag("Parts");
        // mar.setobj=Array.FindAll(objs,obj=>obj.name==this.transform.parent.name.Substring(7))[0];
    }
}
