using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Character
{
    public int Id;
    public string Name;
    public int[] SkillIdList;
}
public class test1 : MonoBehaviour
{
    void Start ()
    {
        var key = "hoge";
        Vector3 vec1=new Vector3(1,2,3);
        Vector3 vec2=new Vector3(4,5,6);
        Vector3 vec3=new Vector3(7,8,9);

        List<Vector3>list=new List<Vector3>()
        {
            vec1,vec2,vec3
        };
        
        Debug.Log(list[0].z);
        
        PlayerPrefsUtils.SetObject( key, list );
        var result = PlayerPrefsUtils.GetObject<List<Vector3>>( key );

        Debug.Log(result.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
