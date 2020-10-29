using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public GameObject cube;
    public GameObject finish_product;
    // Start is called before the first frame update

    void Start()
    {
        string data=PlayerPrefs.GetString("b");

        string [] datas=data.Split('/');
        string [] pos=datas[0].Split(':');
        string [] rot=datas[1].Split(':');
        List<Vector3>list_pos=new List<Vector3>();
        List<Vector3>list_rot=new List<Vector3>();
        List<string>list_color=new List<string>(datas[2].Split(':'));
        Vector3 finish_pro=new Vector3(float.Parse(datas[3].Split(',')[0]),float.Parse(datas[3].Split(',')[1]),float.Parse(datas[3].Split(',')[2]));
        
        for(int i=0;i<pos.Length;i++)
        {
            var a=pos[i].Split(',');
            var b=rot[i].Split(',');
            list_pos.Add(new Vector3(float.Parse(a[0]),float.Parse(a[1]),float.Parse(a[2])));
            list_rot.Add(new Vector3(float.Parse(b[0]),float.Parse(b[1]),float.Parse(b[2])));
        }
        //ここまででPlayerprefsから読み込んで各変数に格納するとこまで//////////////

        finish_product.transform.position=finish_pro;

        for(int i=0;i<list_pos.Count;i++)
        {
            GameObject obj= Instantiate(cube,list_pos[i],Quaternion.identity) as GameObject;
            switch(list_color[i])
            {
                case "white":
                    obj.GetComponent<Renderer>().material.color=Color.white;
                    break;
                case "black":
                    obj.GetComponent<Renderer>().material.color=Color.black;
                    break;
                case "red":
                    obj.GetComponent<Renderer>().material.color=Color.red;
                    break;
                case "blue":
                    obj.GetComponent<Renderer>().material.color=Color.blue;
                    break;
            }
            obj.transform.parent=finish_product.transform;
                
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
