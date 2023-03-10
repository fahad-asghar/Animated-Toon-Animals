using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FishMovement : MonoBehaviour
{
    [SerializeField] GameObject bubbleEffect;
    [SerializeField] [Range(1, 10)] float swimSpeed;

    [SerializeField] AudioClip sound1;
    [SerializeField] AudioClip sound2;
    [SerializeField] AudioClip sound3;

    static int count;

    private void Start()
    {
        count = 0;
        RightMovement();
    }

    private void RightMovement()
    {
        transform.GetChild(1).localScale = new Vector2(Mathf.Abs(transform.GetChild(1).localScale.x), transform.GetChild(1).localScale.y);
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            transform.DOMove(new Vector2(29.5f, 4.29f), swimSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                LeftMovement();
            });
        }

        if (random == 1)
        {
            transform.DOMove(new Vector2(29.5f, 0.45f), swimSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                LeftMovement();
            });
        }

        if (random == 2)
        {
            transform.DOMove(new Vector2(29.5f, -3.84f), swimSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                LeftMovement();
            });
        }
    }

    private void LeftMovement()
    {
        transform.GetChild(1).localScale = new Vector2(-transform.GetChild(1).localScale.x, transform.GetChild(1).localScale.y);
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            transform.DOMove(new Vector2(-29.5f, 4.29f), swimSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                RightMovement();
            });
        }

        if (random == 1)
        {
            transform.DOMove(new Vector2(-29.5f, 0.45f), swimSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                RightMovement();
            });
        }

        if (random == 2)
        {
            transform.DOMove(new Vector2(-29.5f, -3.84f), swimSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                RightMovement();
            });
        }
    }


    private void OnMouseDown()
    {
        count++;

        if (count == 30)
        {
            AdManager.instance.ShowInterstitial();
            count = 0;
        }

        bubbleEffect.GetComponent<ParticleSystem>().Play();
        PlayRandomSound();

        int random = Random.Range(0, 5);
        GetComponent<Collider2D>().enabled = false;

        if (random == 0)
            GetComponent<Animator>().Play("FishAnimation");
        if (random == 1)
            GetComponent<Animator>().Play("FishAnimation2");
        if (random == 2)
            GetComponent<Animator>().Play("FishAnimation3");
        if (random == 3)
            GetComponent<Animator>().Play("FishAnimation4");
        if (random == 4)
            GetComponent<Animator>().Play("FishAnimation5");

        Invoke("Delay", 2);
    }

    private void Delay()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void PlayRandomSound()
    {
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            GetComponent<AudioSource>().clip = sound1;
            GetComponent<AudioSource>().Play();
        }
        else if (random == 1)
        {
            GetComponent<AudioSource>().clip = sound2;
            GetComponent<AudioSource>().Play();
        }
        if (random == 2)
        {
            GetComponent<AudioSource>().clip = sound3;
            GetComponent<AudioSource>().Play();
        }
    }

}
