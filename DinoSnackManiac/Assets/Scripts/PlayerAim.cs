using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAim : MonoBehaviour
{

    public GameObject cookie1;
    public GameObject cookie2;
    public GameObject cookie3;
    public GameObject crosshair;
    public GameObject GameMan;

    private Variables ammo;
    private GameObject cookie;
    private Transform hands;
    private Vector2 lookDirection;
    private Vector3 MouseCoords;
    private float lookAngle;
    private void Start()
    {
        hands = GetComponent<Transform>();
        cookie = cookie1;
        ammo = GameMan.GetComponent<Variables>();


    }
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
        MoveCrossHair();
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
        if (Input.GetButtonDown("1"))
        {
            cookie = cookie1;
        }
        if (Input.GetButtonDown("2"))
        {
            cookie = cookie2;
        }
        if (Input.GetButtonDown("3"))
        {
            cookie = cookie3;
        }
    }
    private void FireBullet()
    {
        if (cookie == cookie1)
        {
            if (ammo.cookieAmmo1 == 0)
            {

            }
            else
            {
                ammo.cookieAmmo1--;
                ammo.cookieText1.text = ammo.cookieAmmo1.ToString();
                GameObject thrownCookie = Instantiate(cookie, hands.position, hands.rotation);
                thrownCookie.GetComponent<Rigidbody2D>().velocity = hands.up * 10f;
                Destroy(thrownCookie, 4.0f);
            }
        }
        else if (cookie == cookie2)
        {
            if (ammo.cookieAmmo2 == 0)
            {

            }
            else
            {
                ammo.cookieAmmo2--;
                ammo.cookieText2.text = ammo.cookieAmmo2.ToString();
                GameObject thrownCookie = Instantiate(cookie, hands.position, hands.rotation);
                thrownCookie.GetComponent<Rigidbody2D>().velocity = hands.up * 10f;
                Destroy(thrownCookie, 4.0f);
            }
        }
        else if (cookie == cookie3)
        {
            if (ammo.cookieAmmo3 == 0)
            {

            }
            else
            {
                ammo.cookieAmmo3--;
                ammo.cookieText3.text = ammo.cookieAmmo3.ToString();
                GameObject thrownCookie = Instantiate(cookie, hands.position, hands.rotation);
                thrownCookie.GetComponent<Rigidbody2D>().velocity = hands.up * 10f;
                Destroy(thrownCookie, 4.0f);
            }
        }
    }
    private void MoveCrossHair()
    {
        MouseCoords = Input.mousePosition;
        MouseCoords = Camera.main.ScreenToWorldPoint(MouseCoords);
        crosshair.transform.position = Vector2.Lerp(transform.position, MouseCoords, 1f);
    }
}
