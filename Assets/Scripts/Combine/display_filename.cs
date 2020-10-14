using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class display_filename : MonoBehaviour
{
    int default_value=0;

    public static string parts="HEAD";

    public Dropdown dd;
    public GameObject choice;
    public GameObject Content;

    void Start()
    {
        List<string>list=GetFileNames();
        foreach(string f in list)
        {
            GameObject obj=Instantiate(choice,choice.transform.position,Quaternion.identity);
            obj.transform.SetParent(Content.transform,false);
            string str=f.Substring(0,f.IndexOf(".prefab"));
            obj.transform.Find("Text").GetComponent<Text>().text=str.Substring(str.IndexOf("_")+1);
        }
    }

    void Update()
    {
        if(default_value!=dd.value)
        {
            set_parts(dd.value);

            foreach(Transform child in Content.transform)GameObject.Destroy(child.gameObject);

            List<string>list=GetFileNames();
            foreach(string f in list)
            {
                GameObject obj=Instantiate(choice);
                obj.transform.SetParent(Content.transform,false);
                string str=f.Substring(0,f.IndexOf(".prefab"));
                obj.transform.Find("Text").GetComponent<Text>().text=str.Substring(str.IndexOf("_")+1);
            }
        }
        default_value=dd.value;
        
    }

    public void set_parts(int value){
        switch(value){
            case 0:
                parts="HEAD";
                break;
            case 1:
                parts="UPPER ARM";
                break;
            case 2:
                parts="LOWER ARM";
                break;
            case 3:
                parts="HAND";
                break;
            case 4:
                parts="BODY";
                break;
            case 5:
                parts="UPPER LEG";
                break;
            case 6:
                parts="LOWER LEG";
                break;
            case 7:
                parts="FOOT";
                break;
        }

    }

    public List<string> GetFileNames(){
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath+"/Resources/");
        FileInfo[] info = dir.GetFiles("*.prefab");
        List<string> list=new List<string>();

        foreach(FileInfo f in info)
        {
            if(parts==f.Name.Substring(0,f.Name.IndexOf("_")))
            {
                list.Add(f.Name);
            }
        }
        
        return list;
    }
}
