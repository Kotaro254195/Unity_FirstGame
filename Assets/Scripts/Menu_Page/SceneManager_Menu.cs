using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager_Menu : MonoBehaviour
{
    public List<GameObject>RightSideObj;
    public List<GameObject>LeftSideObj;

    public Image backimg1;
    public Image backimg2;
    public Image backimg3;
    public Text text;

    bool trigger1=false;
    bool trigger2=false;
    bool trigger3=false;
    public void Transition_Scene()
    {
        Variable_Controller.parts=this.gameObject.name.Substring(7);
        trigger1=true;
    }

    int i=0;
    void Update()
    {
        if(trigger1)
        {
            text.text=this.name.Substring(7);
            i+=1;
            foreach(GameObject obj in RightSideObj){
                Text tx=obj.transform.Find("Text").GetComponent<Text>();
                tx.color=new Color(1f,1f,1f,tx.color.a-0.02f);
            }
            foreach(GameObject obj in LeftSideObj){
                Text tx=obj.transform.Find("Text").GetComponent<Text>();
                tx.color=new Color(1f,1f,1f,tx.color.a-0.02f);
            }
            if(i==50){
                trigger1=false;
                trigger2=true;
                i=0;
            }
        }

        if(trigger2)
        {
            i+=1;
            foreach(GameObject obj in RightSideObj){
                obj.transform.position+=new Vector3(8f,0f,0f);
            }
            foreach(GameObject obj in LeftSideObj){
                obj.transform.position-=new Vector3(8f,0f,0f);
            }
            if(i==120){
                trigger3=true;
                i=0;
                
            }
        }

        if(trigger3)
        {
            backimg1.color=new Color(1f,1f,1f,backimg1.color.a-0.02f);
            backimg2.color=new Color(1f,1f,1f,backimg2.color.a-0.02f);
            backimg3.color=new Color(1f,1f,1f,backimg3.color.a-0.02f);
            text.color=new Color(1f,1f,1f,text.color.a-0.02f);

            if(i==100){
                SceneManager.LoadScene("Custom_Page");
            }
        }
    }

}
