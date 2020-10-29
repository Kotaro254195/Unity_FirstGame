using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Obj;
    public float a;
    public float b;
    public float c;

    // Update is called once per frame
    void Update()
    {
        this.transform.position=new Vector3(Obj.transform.position.x-a,
                                            Obj.transform.position.y+b,
                                            Obj.transform.position.z+c);
        this.transform.LookAt(Obj.transform.position);
    }
}
