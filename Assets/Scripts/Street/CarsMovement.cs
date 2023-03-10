using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarsMovement : MonoBehaviour
{
    [SerializeField] float point1;
    [SerializeField] float scalePoint1;

    [SerializeField] float point2;
    [SerializeField] float scalePoint2;

    [Range(1, 10)]
    [SerializeField] float carMoveSpeed;

    [SerializeField] List<AudioClip> sounds = new List<AudioClip>();

    static int count;

    private void Start()
    {
        count = 0;

        if(gameObject.name != "StaticCars")
            Movement();    
    }

    private void Movement()
    {
        transform.localScale = new Vector2(scalePoint1, transform.localScale.y);
        transform.DOMoveX(point1, carMoveSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
        {
            transform.localScale = new Vector2(scalePoint2, transform.localScale.y);
            transform.DOMoveX(point2, carMoveSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
            {
                Movement();
            });
        });
    }

    private void OnMouseDown()
    {
        count++;

        if(count == 30)
        {
            AdManager.instance.ShowInterstitial();
            count = 0;
        }

        if (gameObject.name == "Bus")
        {
            int randomSoundNumber = Random.Range(0, 4);
            PlayRandomSound(randomSoundNumber);
        }

        if (GetComponent<Animator>() != null)
        {
            if (gameObject.name != "PoliceCar" && gameObject.name != "FireTruck")
            {
                int randomSoundNumber = Random.Range(0, 4);
                PlayRandomSound(randomSoundNumber);

                int random = Random.Range(0, 2);

                if (random == 0)
                    GetComponent<Animator>().Play("StaticCar", -1, 0);
                if (random == 1)
                    GetComponent<Animator>().Play("StaticCar2", -1, 0);
            }
            else
            {
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    int randomSoundNumber = Random.Range(0, 4);
                    PlayRandomSound(randomSoundNumber);                
                    GetComponent<Animator>().Play("StaticCar", -1, 0);
                }
                if (random == 1)
                {
                    int randomSoundNumber = Random.Range(0, 4);
                    PlayRandomSound(randomSoundNumber);
                    GetComponent<Animator>().Play("StaticCar2", -1, 0);
                }
                if (random == 2)
                {
                    GetComponent<Animator>().Play("Siren", -1, 0);
                    if (gameObject.name == "PoliceCar")
                    {
                        int random1 = Random.Range(0, 2);
                        if(random1 == 0)
                            PlayRandomSound(4);
                        if(random1 == 1)
                            PlayRandomSound(6);
                    }
                    else if (gameObject.name == "FireTruck")
                        PlayRandomSound(5);
                }
            }

        }
    }

    private void PlayRandomSound(int index)
    {
        GetComponent<AudioSource>().clip = sounds[index];
        GetComponent<AudioSource>().Play();
    }
}
