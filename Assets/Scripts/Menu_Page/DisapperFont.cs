using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisapperFont : MonoBehaviour
{
    public Text text;

    public bool a=false;

    public int i=1;

    // Update is called once per frame
    void Update()
    {
        i=(i+1)%1700;

        if(i%2==0){
            text.color=new Color(1f,1f,1f,text.color.a-0.085f);
        }else{
            text.color=new Color(1f,1f,1f,text.color.a+0.085f);
        }


        if(a)
        {
            if(i==120||i==240||i==480||i==484||i==488||i==800||i==1300||i==1304||i==1308||i==1312)
            {
                text.color=new Color(1f,1f,1f,0.3f);
            }
            if(i==123||i==243||i==483||i==487||i==491||i==803||i==1103||i==1307||i==1311||i==1315)
            {
                text.color=new Color(1f,1f,1f,0.7f);
            }
        }        
        
        
    }
}
