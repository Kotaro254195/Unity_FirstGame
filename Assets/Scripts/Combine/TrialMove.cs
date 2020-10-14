using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrialMove : MonoBehaviour
{   
    public GameObject humanoid;
    public GameObject pref_humanoid;
    public GameObject head;
    public GameObject upperarm;
    public GameObject lowerarm;
    public GameObject hand;
    public GameObject body;
    public GameObject upperleg;
    public GameObject lowerleg;
    public GameObject foot;
    public List<GameObject> parts=new List<GameObject>();
    public List<Vector3>posivec=new List<Vector3>();
    public List<Quaternion>rotavec=new List<Quaternion>();

    public bool moving=false;

    
    public void move()
    {
        moving=(moving==false);

        if(moving)
        {
            humanoid=GameObject.Find("Human").gameObject;
            Animator anim=humanoid.GetComponent<Animator>();
            anim.enabled=true;
            

            foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
            {
                switch(obj.name)
                {
                    case "HEAD":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=head.transform;                        
                        break;
                    case "UPPER ARM":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=upperarm.transform;                        
                        break;
                    case "LOWER ARM":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=lowerarm.transform;                        
                        break;
                    case "HAND":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=hand.transform;                        
                        break;
                    case "BODY":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=body.transform;                        
                        break;
                    case "UPPER LEG":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=upperleg.transform;                        
                        break;
                    case "LOWER LEG":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=lowerleg.transform;                        
                        break;
                    case "FOOT":
                        parts.Add(obj);
                        posivec.Add(obj.transform.position);
                        rotavec.Add(obj.transform.rotation);
                        obj.transform.parent=foot.transform;                        
                        break;
                }
            }
        }
        else
        {      
            //子オブジェクトとなった各パーツを最上階に移動
            for(int i=0;i<parts.Count;i++)
            {
                parts[i].transform.parent=null;
                parts[i].transform.position=posivec[i];
                parts[i].transform.rotation=rotavec[i];          
            }

            GameObject.Destroy(humanoid);
            GameObject obj= Instantiate(pref_humanoid);
            humanoid=obj;

            obj.name="Human";

            GameObject spine=humanoid.transform.Find("metarig").transform.Find("spine").gameObject;
            head=spine.transform.Find("spine.001").transform.Find("spine.002").transform.Find("spine.003").transform.Find("spine.004").transform.Find("spine.005").transform.Find("spine.006").gameObject;
            upperarm=spine.transform.Find("spine.001").transform.Find("spine.002").transform.Find("spine.003").transform.Find("shoulder.L").transform.Find("upper_arm.L").gameObject;
            lowerarm=upperarm.transform.Find("forearm.L").gameObject;
            hand=lowerarm.transform.Find("hand.L").gameObject;
            body=spine.transform.Find("spine.001").gameObject;
            upperleg=spine.transform.Find("thigh.L").gameObject;
            lowerleg=upperleg.transform.Find("shin.L").gameObject;
            foot=lowerleg.transform.Find("foot.L").gameObject;
        }  
        
        
    }
}