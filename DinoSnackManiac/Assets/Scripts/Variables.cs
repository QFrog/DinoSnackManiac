using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variables : MonoBehaviour
{
    public int cookieAmmo1;
    public int cookieAmmo2;
    public int cookieAmmo3;
    public Text cookieText1;
    public Text cookieText2;
    public Text cookieText3;
    GameObject cookieA;
    Transform cookie;
    private void Start()
    {
    }
    void Update()
    {
        cookieA = GameObject.Find("CookieRefill(Clone)");
        if (cookieA)
        {
            cookie = cookieA.GetComponent<Transform>();
            if (cookie.position.y < -10 || cookie.position.x > 8.5 || cookie.position.x < -8.5)
            {
                Destroy(cookieA.gameObject);
            }
        }
    }
}
