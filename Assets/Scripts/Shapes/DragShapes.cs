using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragShapes : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("DestroyShape", 15);
    }

    public void Drag(Vector2 offset)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(new Vector3(mousePosition.x - offset.x, mousePosition.y - offset.y, transform.position.z));
    }

    public void DestroyShape()
    {
        transform.GetComponent<SpriteRenderer>().DOFade(0, 0.4f).OnComplete(delegate ()
        {
            Destroy(gameObject);
        });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Shape")
        {
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            GetComponent<SpriteRenderer>().DOColor(color, 1);
        }

        GetComponent<AudioSource>().Play();
    }
}
