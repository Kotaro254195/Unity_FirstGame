/*
 * PrefabMan.cs
 * 
 * Copyright (c) 2020 by ConsoleSoup All rights reserved.
 * Created by ConsoleSoup on 2020/02/25.
 * 
 * Blog   ：https://consolesoup.com/unity-prefab-read-write/
 * Twitter：https://twitter.com/consolesoup
 * 
 */
#pragma warning disable 0219

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

/*==============================================================*
 * PrefabMan : GameObjectをprefabとして保存
 *==============================================================*/
public class PrefabMan : MonoBehaviour
{
    //「Assets/Resources/」以下のprefabファイルの保存先
    private string prefabDir = "Prefab/";

    /*----------------------------------------------------------*
     * savePrefab : GameObjectをnameのファイル名でprefabとして保存
     *         in : GameObject gameobject
     *            : string name
     *        out : 
     *----------------------------------------------------------*/
    public void savePrefab(GameObject gameobj, string name)
    {
        //prefabの保存フォルダパス
        // string prefabDirPath = Application.dataPath + "/Resources/"+"/"+ prefabDir;
        // if (!Directory.Exists(prefabDirPath))
        // {
        //     //prefab保存用のフォルダがなければ作成する
        //     Directory.CreateDirectory(prefabDirPath);
        // }

        //prefabの保存ファイルパス
        // string prefabPath = prefabDirPath + name + ".prefab";
        // if (!File.Exists(prefabPath))
        // {
        //     //prefabファイルがなければ作成する
        //     File.Create(prefabPath);
        // }

        //prefabの保存
        UnityEditor.PrefabUtility.CreatePrefab("Assets/Resources/" + name + ".prefab", gameobj);
        UnityEditor.AssetDatabase.SaveAssets();
    }

    /*----------------------------------------------------------*
     * loadPrefab : nameのファイル名で保存してあるprefabを呼び出し
     *         in : string name
     *        out : GameObject gameobject
     *----------------------------------------------------------*/
    public GameObject loadPrefab(string name)
    {
        //prefabファイルの存在確認
        // string prefabPath = Application.dataPath + "/Resources/" + prefabDir + name + ".prefab";*←オリジナル*
        string prefabPath = Application.dataPath + "/Resources/"+ name + ".prefab";
        if (File.Exists(prefabPath))
        {
            //prefabファイルの読み込み
            // string resourcesPath = prefabDir + name; *←オリジナル*
            string resourcesPath = name;
            GameObject gameobj = (GameObject)Resources.Load<GameObject>(resourcesPath);
            if (gameobj)
            {
                return gameobj;
            }
        }
        return null;
    }
}