using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DinoInteraction : MonoBehaviour
{
    [SerializeField] int point1;
    [SerializeField] int point2;
    [SerializeField][Range(0, 10)] float moveSpeed;
    [SerializeField] List<AudioClip> sounds = new List<AudioClip>();

    private Animator animator;

    static int count;

    private void Awake()
    {
        count = 0;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if(gameObject.name != "Dino6" && gameObject.name != "Dino2")
            Move();
    }

    private void Move()
    {
        int randomPoint = Random.Range(point1, point2);

        if (randomPoint > transform.position.x)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);

        else if (randomPoint < transform.position.x)
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            else
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        else if (randomPoint == transform.position.x)
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);

        animator.SetInteger("Condition", 5);
        transform.DOMoveX(randomPoint, moveSpeed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
        {
            animator.SetInteger("Condition", 0);
            Invoke("Move", Random.Range(3, 10));
        });
    }

    private void OnMouseDown()
    {
        count++;

        if (count == 30)
        {
            AdManager.instance.ShowInterstitial();
            count = 0;
        }

        if (gameObject.name != "Dino6" && gameObject.name != "Dino2")
        {
            CancelInvoke();
            DOTween.Kill(transform);
            GetComponent<Collider2D>().enabled = false;

            int random = Random.Range(1, 5);
            animator.SetInteger("Condition", random);
            PlayRandomSound();

            Invoke("ResumeMovement", 2);
        }
        if (gameObject.name == "Dino6")
        {
            PlayRandomSound();
            int random = Random.Range(0, 2);

            if (random == 0)
            {
                GetComponent<Collider2D>().enabled = false;

                transform.DOMoveY(2.58f, moveSpeed, false).SetSpeedBased().OnComplete(delegate ()
                {               
                    transform.DOMoveY(0.98f, moveSpeed, false).SetSpeedBased().OnComplete(delegate ()
                    {
                        GetComponent<Collider2D>().enabled = true;
                    });
                });
            }

            if (random == 1)
            {
                GetComponent<Collider2D>().enabled = false;
                transform.DOMoveX(-10.05f, 6, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
                {
                    transform.localScale = new Vector2(-1, 1);
                    transform.DOMoveX(-0.65f, 6, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
                    {
                        transform.localScale = new Vector2(-1, 1);
                        transform.DOMoveX(10.05f, 6, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
                        {
                            transform.localScale = new Vector2(1, 1);
                            transform.DOMoveX(-0.65f, 6, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
                            {
                                GetComponent<Collider2D>().enabled = true;
                            });
                        });
                    });
                });
            }
        }
        if (gameObject.name == "Dino2")
        {
            PlayRandomSound();

            GetComponent<Collider2D>().enabled = false;
            int random = Random.Range(0, 4);

            if (random == 0)
                animator.Play("Dino2Animation1");
            if (random == 1)
                animator.Play("Dino2Animation2");
            if (random == 2)
                animator.Play("Dino2Animation3");
            if (random == 3)
                animator.Play("Dino2Animation4");

            Invoke("Delay", 2);
        }
    }

    private void Delay()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void ResumeMovement()
    {
        GetComponent<Collider2D>().enabled = true;
        Move();
    }

    private void PlayRandomSound()
    {
        int random = Random.Range(0, sounds.Count);
        GetComponent<AudioSource>().clip = sounds[random];
        GetComponent<AudioSource>().Play();
    }
}
