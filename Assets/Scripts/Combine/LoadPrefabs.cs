using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefabs : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject LoadandColor(GameObject target,string name)
    {
        PrefabMan prefabMan = target.gameObject.GetComponent<PrefabMan>();
        if (prefabMan == null)
        {
            prefabMan = target.gameObject.AddComponent<PrefabMan>();
        }
        //prefabManからロードする
        GameObject obj=prefabMan.loadPrefab(name);
        //～ as Gameobject の形でInstantiateする
        obj=GameObject.Instantiate(obj) as GameObject;

        
        return obj;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
