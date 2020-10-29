using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Submit_Button : MonoBehaviour
{
    public GameObject text;
    public InputField input;

    public GameObject Finished_Product;


    
    public void Submit()
    {
        List<float>x=new List<float>();
        List<float>y=new List<float>();
        List<float>z=new List<float>();

        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.activeInHierarchy)
            {
                if (obj.name.Contains("Cube(original)"))
                {
                    x.Add(obj.transform.position.x);
                    y.Add(obj.transform.position.y);
                    z.Add(obj.transform.position.z);
                }
            }
        }
        Finished_Product.transform.position=new Vector3(x.Average(),y.Average(),z.Average());

        //作った全オブジェクトをFinished_Productの子要素とする。
        // foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        // {
        //     if (obj.activeInHierarchy)
        //     {
        //         if (obj.name.Contains("Cube(original)"))
        //         {

        //             foreach(Transform child in obj.transform)
        //             {
        //                 GameObject.Destroy(child.gameObject);
        //             }
                    
        //             obj.transform.parent = Finished_Product.transform;
        //         }
        //     }
        // }

        // 作った全オブジェクトのPosition,RotationデータをPlayerprefsで保存
        string str_pos="";
        string str_rot="";
        string str_color="";
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.activeInHierarchy)
            {
                if (obj.name.Contains("Cube(original)"))
                {
                    str_pos+=obj.transform.position.x+","+
                    obj.transform.position.y+","+
                    obj.transform.position.z+":";

                    str_rot+=obj.transform.rotation.x+","+
                    obj.transform.rotation.y+","+
                    obj.transform.rotation.z+":";

                    str_color+=obj.name.Substring(14)+":";
                    
                }
            }
        }

        PlayerPrefs.SetString(input.text,str_pos.Substring(0,str_pos.Length-1)+"/"+
                                         str_rot.Substring(0,str_rot.Length-1)+"/"+
                                         str_color.Substring(0,str_color.Length-1)+"white"+"/"+
                                         Finished_Product.transform.position.x+","+
                                         Finished_Product.transform.position.y+","+
                                         Finished_Product.transform.position.z
                             );
        PlayerPrefs.SetString(Variable_Controller.parts+"parts",
                                PlayerPrefs.GetString(Variable_Controller.parts+"parts")+input.text+",");
        
        Debug.Log(PlayerPrefs.GetString(input.text)+"保存成功");
        Debug.Log(PlayerPrefs.GetString(Variable_Controller.parts+"parts")+"保存成功");

        SceneManager.LoadScene("Menu");

        // Invoke("move",2f);
    }

    public void move(){

        PrefabMan prefabMan = this.gameObject.GetComponent<PrefabMan>();
        if (prefabMan == null)
        {
            prefabMan = this.gameObject.AddComponent<PrefabMan>();
        }

        prefabMan.savePrefab(Finished_Product, Variable_Controller.parts+"_"+input.text);
        SceneManager.LoadScene("Menu");
    }
}
