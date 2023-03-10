using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailFollowShape : MonoBehaviour
{
    public Transform shapeToFollow;

    private void Start()
    {
        Invoke("DestroyTrail", 16);
    }

    void Update()
    {
        if(shapeToFollow != null)
            transform.position = shapeToFollow.position;
    }

    private void DestroyTrail()
    {
        Destroy(gameObject);
    }
}
