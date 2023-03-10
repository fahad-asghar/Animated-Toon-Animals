using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushAndTree : MonoBehaviour
{

    [SerializeField] List<AudioClip> sounds = new List<AudioClip>();


    private void OnMouseDown()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Collider2D>().enabled = false;

        if (transform.childCount > 0)
            transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

        int random = Random.Range(0, 2);
        if (random == 0)
            GetComponent<Animator>().Play("Bush", -1, 0);
        if (random == 1)
            GetComponent<Animator>().Play("Clip2", -1, 0);

        PlayRandomSound();

        Invoke("Delay", 2);
    }

    private void Delay()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<AudioSource>().Stop();
    }




    private void PlayRandomSound()
    {
        int random = Random.Range(0, sounds.Count);
        GetComponent<AudioSource>().clip = sounds[random];
        GetComponent<AudioSource>().Play();
    }
}
