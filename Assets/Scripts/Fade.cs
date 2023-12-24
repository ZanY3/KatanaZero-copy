using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public SpriteRenderer rndrer;
    public bool isStart;
    void Start()
    {
        rndrer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
        {
            var color = rndrer.color;
            color.a += Time.deltaTime;

            rndrer.color = color;
        }
        if (isStart)
        {
            var color = rndrer.color;
            color.a -= Time.deltaTime;

            rndrer.color = color;
        }
    }
}
