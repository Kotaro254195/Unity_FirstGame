using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Touched : MonoBehaviour
{
    MoveAndRoll mar;

    void Start()
    {
        mar=GameObject.Find("MoveAndRoll_Controller").GetComponent<MoveAndRoll>();
    }

    public void Touch()
    {
        mar.setobj=this.gameObject;
    }
}
