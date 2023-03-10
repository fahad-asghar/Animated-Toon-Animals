using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    bool invert = true;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (invert)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            invert = false;
            return;
        }

        if(!invert)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            invert = true;
            return;
        }
    }
}
