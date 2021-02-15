using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fade;
    float fades = 0f;

    Color colorStart = Color.clear;
    Color colorEnd = Color.black;

    GameController gameController;   
    private void OnEnable()
    {
        fades = 0;
        fade.transform.gameObject.SetActive(true);
        fade.color = Color.clear;
       
        StartCoroutine(SetFade());
    }

	private void Update()
	{
		
	}
	private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    IEnumerator SetFade()
    {
        while (fades < 1f)
        {
            fades += 0.05f;
            fade.color = Color.Lerp(colorStart, colorEnd, fades);

            if (fades > 1f)
            {
                fade.color = Color.black;
                fades = 0f;
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.025f);

        while (fades < 1f)
        {
            fades += 0.05f;
            fade.color = Color.Lerp(colorEnd, colorStart, fades);

            if (fades > 1f)
            {
                fade.color = Color.clear;
                fade.transform.gameObject.SetActive(false);
                GetComponent<Fade>().enabled = false;
                break;
            }
            yield return null;
        }

     
        yield return null;
    }

    private void OnDisable()
    {
        StopCoroutine(SetFade());
        gameController.AddDialogIndex();
        gameController.Action();
    }
}
