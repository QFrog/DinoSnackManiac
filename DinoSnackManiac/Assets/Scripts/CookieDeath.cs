using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieDeath : MonoBehaviour
{
    private float timer;
    void Update()
    {
        GameObject c1 = GameObject.Find("CookieType1(Clone)");
        GameObject c2 = GameObject.Find("CookieType2(Clone)");
        GameObject c3 = GameObject.Find("CookieType3(Clone)");
        timer += 1.0F * Time.deltaTime;
        if (c1)
            if (timer >= 4)
            {
                Destroy(c1.gameObject);
                timer = 0;
            }
        if (c2)
        {

            if (timer >= 4)
            {
                Destroy(c2.gameObject);
                timer = 0;
            }
        }
        if (c3)
        {

            if (timer >= 4)
            {
                Destroy(c2.gameObject);
                timer = 0;
            }
        }
    }
}
