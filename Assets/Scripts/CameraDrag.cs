using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    Vector3 startPosition;
    Vector3 currentPosition;
    Vector3 cameraPosition;

    [SerializeField] float scrollSpeed = .5f;
    public static CameraDrag instance;
    [HideInInspector] public bool dragEnable;

    private void Awake()
    {
        instance = this;
        dragEnable = true;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            cameraPosition = transform.position;
        }

        if (Input.GetMouseButton(0) && dragEnable)
        {
            currentPosition = Input.mousePosition;
            ScrollCamera();
        }
    }

    void ScrollCamera()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(currentPosition) - Camera.main.ScreenToWorldPoint(startPosition);
        direction = direction * -scrollSpeed;
        Vector3 position = cameraPosition + direction;
        transform.position = new Vector3(Mathf.Clamp(position.x, point1.position.x, point2.position.x), transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, new Vector3(position.x, transform.position.y, transform.position.z), 10);
        
    }
}
