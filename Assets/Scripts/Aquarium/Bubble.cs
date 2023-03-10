using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bubble : MonoBehaviour
{
    [SerializeField] GameObject splash;

    void Start()
    {
        transform.DOMove(new Vector2(transform.position.x + Random.Range(-6, 6), 7), 0.5f, false).SetEase(Ease.Linear).SetSpeedBased().OnComplete(delegate() 
        {
            Destroy(gameObject);
        });    
    }

    private void OnMouseDown()
    {
        DOTween.Kill(transform);
        GameObject obj = Instantiate(splash, transform.position, Quaternion.Euler(-90, 0, 0));
        obj.GetComponent<AudioSource>().Play();

        Destroy(gameObject);
    }
}
