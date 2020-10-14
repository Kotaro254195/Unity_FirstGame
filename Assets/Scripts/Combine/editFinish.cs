using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class editFinish : MonoBehaviour
{
    public GameObject head;
    public GameObject upperarm;
    public GameObject lowerarm;
    public GameObject hand;
    public GameObject body;
    public GameObject upperleg;
    public GameObject lowerleg;
    public GameObject foot;

    public GameObject Object;

    public void Finish()
    {
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
            {
                switch(obj.name)
                {
                    case "HEAD":      
                        obj.transform.parent=head.transform;                        
                        break;
                    case "UPPER ARM":
                        obj.transform.parent=upperarm.transform;                        
                        break;
                    case "LOWER ARM":
                        obj.transform.parent=lowerarm.transform;                        
                        break;
                    case "HAND":
                        obj.transform.parent=hand.transform;                        
                        break;
                    case "BODY":
                        obj.transform.parent=body.transform;                        
                        break;
                    case "UPPER LEG":
                        obj.transform.parent=upperleg.transform;                        
                        break;
                    case "LOWER LEG":
                        obj.transform.parent=lowerleg.transform;                        
                        break;
                    case "FOOT":
                        obj.transform.parent=foot.transform;                        
                        break;
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

        prefabMan.savePrefab(Object, "Demo");
        SceneManager.LoadScene("Menu");
    }
}
