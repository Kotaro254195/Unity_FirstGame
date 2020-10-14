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
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.activeInHierarchy)
            {
                if (obj.name.Contains("Cube(original)"))
                {

                    foreach(Transform child in obj.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    
                    obj.transform.parent = Finished_Product.transform;
                }
            }
        }

        Invoke("move",2f);
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
