using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    [SerializeField] GameObject fader;


    private void Awake()
    {
        Camera.main.aspect = 1920f / 1080f;
        fader.SetActive(true);
    }

    void Start()
    {
        fader.transform.DOLocalMoveX(-2200, 1, false).OnComplete(delegate ()
        {
            fader.SetActive(false);
        });
    }

    public void Aquarium()
    {
        ChangeScene("Aquarium");
    }

    public void Shapes()
    {
        ChangeScene("Shapes");
    }

    public void Zoo()
    {
        ChangeScene("Zoo");
    }

    public void DinoWorld()
    {
        ChangeScene("Dino World");
    }

    public void Street()
    {
        ChangeScene("Street");
    }

    public void SceneSelection()
    {
        ChangeScene("SceneSelection");
    }

    public void ChangeScene(string sceneName)
    {
        AdManager.instance.ShowInterstitial();
        GetComponent<AudioSource>().Play();
        fader.transform.DOLocalMoveX(2200, 0, false).OnComplete(delegate ()
        {
            fader.SetActive(true);
            fader.transform.DOLocalMoveX(0, 1, false).OnComplete(delegate ()
            {
                SceneManager.LoadScene(sceneName);
            });
        });
    }

   
}
