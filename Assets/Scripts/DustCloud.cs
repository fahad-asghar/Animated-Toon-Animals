using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustCloud : MonoBehaviour
{
    [SerializeField] GameObject dust;
    private void OnMouseDown()
    {
        Instantiate(dust, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), Quaternion.Euler(-90, 0, 0));
    }
}
