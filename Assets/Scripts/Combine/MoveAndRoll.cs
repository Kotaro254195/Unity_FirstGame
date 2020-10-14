using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRoll : MonoBehaviour
{
    public GameObject setobj;

    bool push=false;

    string ui;

    public void PushDown(string name){push=true;ui=name;}
    public void PushUp(){push=false;}

    public int a=-30;

    void Update()
    {
        if(push)Move();
    }

    void Move()
    {
        if(push)
        {
            switch(ui)
            {
                case "Button_Up":
                    setobj.transform.position+=new Vector3(0,0.1f,0);
                    break;
                case "Button_Right":
                    setobj.transform.position+=new Vector3(0.1f,0,0);
                    break;
                case "Button_Left":
                    setobj.transform.position+=new Vector3(-0.1f,0,0);
                    break;
                case "Button_Down":
                    setobj.transform.position+=new Vector3(0,-0.1f,0);
                    break;
                case "Button_RollUp":
                    setobj.transform.Rotate(new Vector3(1f,0,0));
                    break;
                case "Button_RollRight":
                    setobj.transform.Rotate(new Vector3(0,1f,0));
                    break;
                case "Button_RollLeft":
                    setobj.transform.Rotate(new Vector3(0,-1f,0));
                    break;
                case "Button_RollDown":
                    setobj.transform.Rotate(new Vector3(-1f,0,0));
                    break;
                case "Button_Forward":
                    setobj.transform.position+=new Vector3(0,0,-0.08f);
                    break;
                case "Button_Back":
                    setobj.transform.position+=new Vector3(0,0,0.08f);
                    break;
            }
        }
    }
}
