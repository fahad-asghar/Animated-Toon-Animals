using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject fader;

    private void Start()
    {
        text1.transform.DOLocalMoveY(82, 1.5f, false);
        text2.transform.DOLocalMoveY(-82, 1.5f, false).OnComplete(delegate ()
        {
            Invoke("Delay", 3);
        });
    }

    private void Delay()
    {
        fader.SetActive(true);
        fader.transform.DOLocalMoveX(0, 1, false).OnComplete(delegate ()
        {
            SceneManager.LoadScene("SceneSelection");
        });
    }
}
