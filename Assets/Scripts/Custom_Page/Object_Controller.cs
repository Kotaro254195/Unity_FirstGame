using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Controller : MonoBehaviour
{
    public GameObject cube;
    Vector3 cube_vec;
    public Dropdown dd;

    public Material material_white;
    public Material material_black;
    public Material material_red;
    public Material material_blue;

    public void Start()
    { cube_vec = this.transform.parent.transform.position; }


    public void Push()
    {
        if(Input.GetMouseButton(0))
        {
            Add_or_Delete(this.transform.name);
        }
        
    }

    public void Add_or_Delete(string place)
    {
        if(Button_Controller.mode=="Add")
        {
            GameObject obj=null;
            switch (place)
            {                
                case "Plane_top":
                    obj = Instantiate(cube, new Vector3(cube_vec.x, cube_vec.y + cube.transform.localScale.y, cube_vec.z), cube.transform.rotation);
                    break;
                case "Plane_bottom":
                    obj = Instantiate(cube, new Vector3(cube_vec.x, cube_vec.y - cube.transform.localScale.y, cube_vec.z), cube.transform.rotation);
                    break;
                case "Plane_flont":
                    obj = Instantiate(cube, new Vector3(cube_vec.x, cube_vec.y, cube_vec.z - cube.transform.localScale.z), cube.transform.rotation);
                    break;
                case "Plane_back":
                    obj = Instantiate(cube, new Vector3(cube_vec.x, cube_vec.y, cube_vec.z + cube.transform.localScale.z), cube.transform.rotation);
                    break;
                case "Plane_left":
                    obj = Instantiate(cube, new Vector3(cube_vec.x - cube.transform.localScale.x, cube_vec.y, cube_vec.z), cube.transform.rotation);
                    break;
                case "Plane_right":
                    obj = Instantiate(cube, new Vector3(cube_vec.x + cube.transform.localScale.x, cube_vec.y, cube_vec.z), cube.transform.rotation);
                    break;
            }

            switch (dd.value)
            {
                case 0:
                    obj.GetComponent<Renderer>().material = material_white;
                    obj.name="Cube(original)white";
                    break;
                case 1:
                    obj.GetComponent<Renderer>().material = material_black;
                    obj.name="Cube(original)black";
                    break;
                case 2:
                    obj.GetComponent<Renderer>().material = material_blue;
                    obj.name="Cube(original)blue";
                    break;
                case 3:
                    obj.GetComponent<Renderer>().material = material_red;
                    obj.name="Cube(original)red";
                    break;
            }


            // インスタンスのルートを渡してPrefabとの接続を解除する
            // PrefabUtility.UnpackPrefabInstance(obj, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
            
        }
        else if (Button_Controller.mode == "Delete" && this.transform.parent.transform.name != "Cube(original)")
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
