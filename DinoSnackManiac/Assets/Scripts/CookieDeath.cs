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
        if (c1)
            timer += 1.0F * Time.deltaTime;
            if (timer >= 3)
            {
                Destroy(c1.gameObject);
                timer = 0;
            }
        if (c2)
        {
            timer += 1.0F * Time.deltaTime;
            if (timer >= 4)
            {
                Destroy(c2.gameObject);
                timer = 0;
            }
        }
        if (c3)
        {
            timer += 1.0F * Time.deltaTime;
            if (timer >= 4)
            {
                Destroy(c2.gameObject);
                timer = 0;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        UnityEngine.Debug.Log("Colliding on object: " + coll.gameObject.tag);

        if (coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
        }
    }
}
