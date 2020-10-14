using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour
{
    public string Scene_name;

    public void Transition_Scene()
    {
        Variable_Controller.parts=this.gameObject.name;
        SceneManager.LoadScene(Scene_name);
    }
}
