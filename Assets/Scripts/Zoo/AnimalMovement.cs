using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimalMovement : MonoBehaviour
{

    [SerializeField] int point1;
    [SerializeField] int point2;

    [SerializeField][Range(0, 10)] float speed;
    [SerializeField] List<AudioClip> sounds = new List<AudioClip>();

    private Animator animator;
    bool objectClicked = false;

    static int count;

    private void Awake()
    {
        count = 0;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
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


        animator.SetInteger("Condition", 6);
        transform.DOMoveX(randomPoint, speed, false).SetSpeedBased().SetEase(Ease.Linear).OnComplete(delegate ()
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

        CancelInvoke();
        DOTween.Kill(transform);
        GetComponent<Collider2D>().enabled = false;

        int random = Random.Range(1, 6);
        animator.SetInteger("Condition", random);
        PlayRandomSound();

        Invoke("ResumeMovement", 2);
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
