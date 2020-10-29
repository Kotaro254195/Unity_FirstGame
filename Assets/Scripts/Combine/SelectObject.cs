using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectObject :  MonoBehaviour
{
    public Text text;
    public GameObject Content;
    public GameObject choice2;
    public MoveAndRoll mar;

    void Start()
    {
        Content=GameObject.Find("Scroll View2").transform.Find("Viewport").transform.Find("Content").gameObject;
        mar=GameObject.Find("MoveAndRoll_Controller").gameObject.GetComponent<MoveAndRoll>();
    }

    public void Select()
    {
        string name=text.text;
        string parts=display_filename.parts;
        string name_obj=parts+"_"+name;

        bool b=false;

        if(GameObject.Find(parts)!=null)
        {
            GameObject gobj=GameObject.Find(parts).gameObject;
            if(mar.setobj==gobj)b=true;
            
            Destroy(GameObject.Find(parts).gameObject);
        }
        if(Content.transform.Find("Button_"+parts)!=null)
        {
            Destroy(Content.transform.Find("Button_"+parts).gameObject);
        }

        ////////////////////////////////////////////////////////////
        GameObject ob=Instantiate(choice2);        
        ob.transform.parent=Content.transform;
        ob.transform.Find("Button").transform.Find("Text").GetComponent<Text>().text=parts;
        ob.name="Button_"+parts;
        ////////////////////////////////////////////////////////////

        // GameObject obj=LoadPrefabs.LoadandColor(this.gameObject,name_obj);
        GameObject obj=ObjectManager.CreateObject(name);
        obj.name=parts;
        if(b)mar.setobj=obj;

        Touched touched= obj.AddComponent<Touched>();

        foreach(Transform child in obj.transform)
        {
            EventTrigger et=child.gameObject.AddComponent<EventTrigger>();
            et.triggers=new List<EventTrigger.Entry>();
            EventTrigger.Entry entry=new EventTrigger.Entry();
            entry.eventID=EventTriggerType.PointerDown;
            entry.callback.AddListener((x)=>{touched.Touch(); });
            et.triggers.Add(entry);
        }    

        ob.transform.localScale=new Vector3(1,1,1);

    }

}
