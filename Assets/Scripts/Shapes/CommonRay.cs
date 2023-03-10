using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonRay : MonoBehaviour
{
    bool drag = false;
    Vector3 offset;
    RaycastHit2D hit;
    public static CommonRay instance;
    GameObject temp;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

            if (hit.collider != null)
            {
                offset = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - hit.collider.GetComponent<Rigidbody2D>().position;
                drag = true;
                CameraDrag.instance.dragEnable = false;
                GetComponent<AudioSource>().Play();
            }
        }


        if (Input.GetMouseButton(0) && drag)
        {
            if(hit.collider != null)
                hit.collider.GetComponent<DragShapes>().Drag(offset);
            if (temp != null)
                temp.GetComponent<DragShapes>().Drag(offset);
        }

        if (Input.GetMouseButtonUp(0))
        {
            CameraDrag.instance.dragEnable = true;
            temp = null; 
        }
        
    }


    public void GetPositionAtSpawn(GameObject spawnedObject)
    {
        temp = spawnedObject;
        offset = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - spawnedObject.GetComponent<Rigidbody2D>().position;
        drag = true;
        CameraDrag.instance.dragEnable = false;
    }
}
