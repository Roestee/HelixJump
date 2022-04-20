using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashControl : MonoBehaviour
{
    private Color color;

    private void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void Update()
    {
        if (color.a >= 0.1f)
        {
            color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0, 0.001f));
            GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
