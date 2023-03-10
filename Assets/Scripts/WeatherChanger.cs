using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WeatherChanger : MonoBehaviour
{
    [SerializeField] GameObject sky;
    [SerializeField] GameObject sun;
    [SerializeField] GameObject moon;
    [SerializeField] GameObject rain;

    [SerializeField] GameObject bg;
    [SerializeField] GameObject background;


    private void OnMouseDown()
    {
        if (gameObject.name == "Sun")
        {
            GetComponent<AudioSource>().Play();
            sun.GetComponent<Collider2D>().enabled = false;
            moon.GetComponent<Collider2D>().enabled = false;

            moon.GetComponent<SpriteRenderer>().DOFade(0, 0).OnComplete(delegate ()
            {
                moon.SetActive(true);
                moon.GetComponent<SpriteRenderer>().DOFade(1, 1).OnComplete(delegate ()
                {
                    moon.GetComponent<Collider2D>().enabled = true;
                });
            });
            sun.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(delegate ()
            {
                sun.SetActive(false);
            });

            background.GetComponent<SpriteRenderer>().DOColor(new Color(0.65f, 0.65f, 0.65f, 1), 1);

            if (SceneManager.GetActiveScene().name == "Street")
            {
                bg.GetComponent<SpriteRenderer>().DOFade(1, 1).OnComplete(delegate() {                                     
                    bg.transform.GetChild(Random.Range(0, 3)).GetComponent<SpriteRenderer>().DOFade(1, 1);
                });
            }
          
            sky.GetComponent<SpriteRenderer>().DOColor(new Color(0.1415094f, 0.1415094f, 0.1415094f, 1), 1);
        }

        if (gameObject.name == "Moon")
        {
            GetComponent<AudioSource>().Play();
            sun.GetComponent<Collider2D>().enabled = false;
            moon.GetComponent<Collider2D>().enabled = false;

            sun.GetComponent<SpriteRenderer>().DOFade(0, 0).OnComplete(delegate ()
            {
                sun.SetActive(true);
                sun.GetComponent<SpriteRenderer>().DOFade(1, 1).OnComplete(delegate ()
                {
                    sun.GetComponent<Collider2D>().enabled = true;
                });
            });
            moon.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(delegate ()
            {
                moon.SetActive(false);
            });

            background.GetComponent<SpriteRenderer>().DOColor(new Color(1f, 1f, 1f, 1), 1);


            if (SceneManager.GetActiveScene().name == "Street")
            {
                bg.GetComponent<SpriteRenderer>().DOFade(0, 1);
                bg.transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0, 1);
                bg.transform.GetChild(1).GetComponent<SpriteRenderer>().DOFade(0, 1);
                bg.transform.GetChild(2).GetComponent<SpriteRenderer>().DOFade(0, 1);
            }

            sky.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 1);
        }

        if (gameObject.name == "Cloud")
        {
            if (rain.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity == 0)
            {
                GetComponent<AudioSource>().Play();
                rain.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity = 0.6f;
                rain.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                rain.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
                rain.transform.GetChild(2).GetComponent<ParticleSystem>().Play();

                transform.DOScale(new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f), 0.2f).OnComplete(delegate ()
                {
                    transform.DOScale(new Vector2(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f), 0.2f).OnComplete(delegate ()
                    {
                        transform.DOScale(new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f), 0.2f).OnComplete(delegate ()
                        {

                        });
                    });
                });


                Invoke("DisableRain", 10);
            }
        }
    }

    private void DisableRain()
    {
        rain.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity = 0f;
    }
}
