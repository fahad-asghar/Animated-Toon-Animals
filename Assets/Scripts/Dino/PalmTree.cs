using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AudioSource>().Play();

        int random = Random.Range(0, 2);

        if (random == 0)
            GetComponent<Animator>().Play("PalmTree", -1, 0);
        if (random == 1)
            GetComponent<Animator>().Play("PalmTree1", -1, 0);

        Invoke("Delay", 2);
    }

    private void Delay()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<AudioSource>().Stop();
    }
}
