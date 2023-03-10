using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    int count = 0;

    [SerializeField] List<AudioClip> sounds = new List<AudioClip>();

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().clip = sounds[count];
        GetComponent<AudioSource>().Play();

        count++;

        if (count == 1)
            Handheld.Vibrate();
        if (count == 2)
            Handheld.Vibrate();
        if (count == 3)
            Handheld.Vibrate();
        if (count == 4)
        {
            Handheld.Vibrate();
            count = 0;           
            GetComponent<Collider2D>().enabled = false;
            transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            Invoke("Delay", 10);
        }
    }

    private void Delay()
    {
        GetComponent<AudioSource>().Stop();
        transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
        GetComponent<Collider2D>().enabled = true;
    }
}
