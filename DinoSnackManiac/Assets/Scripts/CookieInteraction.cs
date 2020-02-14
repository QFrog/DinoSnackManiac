using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieInteraction : MonoBehaviour
{
    private float timer;
    void Update()
    {
        GameObject c1 = GameObject.Find("CookieType1(Clone)");
        GameObject c2 = GameObject.Find("CookieType2(Clone)");
        GameObject c3 = GameObject.Find("CookieType3(Clone)");
        if (c1)
        {
            timer += 1.0F * Time.deltaTime;
            if (timer >= 3)
            {
                Destroy(c1.gameObject);
                timer = 0;
            }
        }
        else if (c2)
        {
            timer += 1.0F * Time.deltaTime;
            if (timer >= 4)
            {
                Destroy(c2.gameObject);
                timer = 0;
            }
        }
        else if (c3)
        {
            timer += 1.0F * Time.deltaTime;
            if (timer >= 4)
            {
                Destroy(c3.gameObject);
                timer = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
