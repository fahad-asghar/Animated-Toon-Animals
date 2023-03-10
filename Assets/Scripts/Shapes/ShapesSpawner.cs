using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShapesSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> shapes = new List<GameObject>();
    [SerializeField] GameObject trail;
    [SerializeField] float time;
    bool stopSpawn = false;
    Vector3 mousePosition;
    GameObject obj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))        
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButton(0) && !stopSpawn)
        {
            time = time + Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

            if (time >= 0.25f && Vector2.Distance(mousePosition, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 0.2f && hit.collider == null)
            {
                stopSpawn = true;
                time = 0;
                SpawnShape();
            }
            else if(time > 0.25f)
                stopSpawn = true;           
        }

        if (Input.GetMouseButtonUp(0))
        {
            time = 0;
            stopSpawn = false;
            EnablePhysics();
        }
    }

    private void SpawnShape()
    {
        GetComponent<AudioSource>().Play();

        int random = Random.Range(0, shapes.Count);
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        obj = Instantiate(shapes[random], new Vector3(position.x, position.y, 0), Quaternion.identity);

        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        obj.GetComponent<SpriteRenderer>().DOColor(color, 0);     
        obj.GetComponent<SpriteRenderer>().DOFade(1, 0.3f);

        GameObject traill = Instantiate(trail, obj.transform.position, Quaternion.Euler(-90, 0, 0));
        traill.GetComponent<TailFollowShape>().shapeToFollow = obj.transform;
        traill.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

        CommonRay.instance.GetPositionAtSpawn(obj);
    }

    private void EnablePhysics()
    {
        if (obj != null)
        {
            obj.GetComponent<Rigidbody2D>().isKinematic = false;
            obj.GetComponent<Rigidbody2D>().gravityScale = 4;
            obj.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }
}
