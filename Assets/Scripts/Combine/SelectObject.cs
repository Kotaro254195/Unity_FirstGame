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

    void Start()
    {
        Content=GameObject.Find("Scroll View2").transform.Find("Viewport").transform.Find("Content").gameObject;
    }

    public void Select()
    {
        string name=text.text;
        string parts=display_filename.parts;
        string name_obj=parts+"_"+name;

        if(GameObject.Find(parts)!=null)
        {
            Destroy(GameObject.Find(parts).gameObject);
        }
        if(Content.transform.Find(parts)!=null)
        {
            Destroy(Content.transform.Find(parts).gameObject);
        }

        GameObject ob=Instantiate(choice2);
        
        ob.transform.parent=Content.transform;
        ob.transform.Find("Button").transform.Find("Text").GetComponent<Text>().text=parts;
        ob.name=parts;

        GameObject obj=LoadPrefabs.LoadandColor(this.gameObject,name_obj);
        obj.name=parts;

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
