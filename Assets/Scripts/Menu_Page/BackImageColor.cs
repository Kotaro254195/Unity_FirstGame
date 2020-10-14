using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackImageColor : MonoBehaviour
{
    public Image img_back;

    public float i = 0;

    void Update()
    {
        i = (float)(i+0.5)%365;
        img_back.color = ColorHSV.FromHsv((int)i, 255, 255);
    }
}
