using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public string name;

    public void Change_Scene()
    {
        SceneManager.LoadScene(name);
    }
}
