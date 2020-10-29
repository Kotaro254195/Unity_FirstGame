using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Controller : MonoBehaviour
{
    public GameObject cam;

    public GameObject cube;

    public float height=0;

    float X;
    float Y;
    float z;
    
    void Start()
    {
        cam.transform.LookAt(cube.transform);
    }

    void Update() 
    {
        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1)) 
        {
            // マウスの移動量
            X = Input.GetAxis("Mouse X");
            Y = Input.GetAxis("Mouse Y");

            cam.transform.Translate(Vector3.left*X*0.1f);
            cam.transform.Translate(Vector3.down*Y*0.1f);

            cam.transform.LookAt(new Vector3(0,height,0));
        }
        // else if(Input.GetMouseButton(1)&&Button_Controller.rotation=="vertical")
        // {
        //     X = Input.GetAxis("Mouse X");
        //     Y = Input.GetAxis("Mouse Y");

        //     cam.transform.Rotate(transform.up,X*1.1f);
        //     cam.transform.Rotate(transform.right,Y*1.1f);
            
        //     // cam.transform.Rotate(transform.right,Y*1.1f);
        // }

        z=Input.GetAxis("Mouse ScrollWheel");
        cam.transform.Translate(Vector3.forward*z*4f);

        // if (Input.GetMouseButton(2))
        // {
        //     Y = Input.GetAxis("Mouse Y");
        //     height+=Y*0.5f;
        // }
    }   

}
