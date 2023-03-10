using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public static GameObject obj;
    public static int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (obj != null)
        {
            Destroy(obj);
        }
        obj = gameObject;
        DontDestroyOnLoad(obj);



    }
}
