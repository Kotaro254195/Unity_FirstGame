using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour
{

    public static string mode = null; //Add or Delete
    public Button set_btn;

    public Image img_Button;
    public Sprite lateral;
    public Sprite vertical;
    

    public GameObject finish_image;

    void Start()
    {
        mode = "Add";
        set_btn = GameObject.Find("Canvas").transform.Find("Button_Add").GetComponent<Button>();
        set_btn.interactable = false;
    }

    public void Add_Button()
    {
        mode = "Add";
        set_btn.interactable = true;
        set_btn = GameObject.Find("Canvas").transform.Find("Button_Add").GetComponent<Button>();
        set_btn.interactable = false;
    }
    public void Delete_Button()
    {
        mode = "Delete";
        set_btn.interactable = true;
        set_btn = GameObject.Find("Canvas").transform.Find("Button_Delete").GetComponent<Button>();
        set_btn.interactable = false;
    }

    public void Finish()
    {
        // mode = null;
        finish_image.gameObject.SetActive(true);

        
    }

    
}