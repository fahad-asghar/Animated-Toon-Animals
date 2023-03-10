using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    [SerializeField] GameObject splash;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(splash, new Vector2(position.x, position.y), Quaternion.Euler(90, 0, 0));
    }
}
