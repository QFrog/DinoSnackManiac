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
    public Text cookieText1;
    public Text cookieText2;
    public Text cookieText3;
    int cookieAmmo1 = 10;
    int cookieAmmo2 = 10;
    int cookieAmmo3 = 10;

    private GameObject cookie;
    private Transform hand;
    private Vector2 lookDirection;
    private Vector3 MouseCoords;
    private float lookAngle;
    private void Start()
    {
        hand = GetComponent<Transform>();
        cookie = cookie1;
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
            if (cookieAmmo1 == 0)
            {

            }
            else
            {
                cookieAmmo1--;
                cookieText1.text = cookieAmmo1.ToString();
                GameObject thrownCookie = Instantiate(cookie, hand.position, hand.rotation);
                thrownCookie.GetComponent<Rigidbody2D>().velocity = hand.up * 10f;
            }
        }
        else if (cookie == cookie2)
        {
            if (cookieAmmo2 == 0)
            {

            }
            else
            {
                cookieAmmo2--;
                cookieText2.text = cookieAmmo2.ToString();
                GameObject thrownCookie = Instantiate(cookie, hand.position, hand.rotation);
                thrownCookie.GetComponent<Rigidbody2D>().velocity = hand.up * 10f;
            }
        }
        else if (cookie == cookie3)
        {
            if (cookieAmmo3 == 0)
            {

            }
            else
            {
                cookieAmmo3--;
                cookieText3.text = cookieAmmo3.ToString();
                GameObject thrownCookie = Instantiate(cookie, hand.position, hand.rotation);
                thrownCookie.GetComponent<Rigidbody2D>().velocity = hand.up * 10f;
            }
        }
    }
    private void MoveCrossHair()
    {
        MouseCoords = Input.mousePosition;
        MouseCoords = Camera.main.ScreenToWorldPoint(MouseCoords);
        crosshair.transform.position = Vector2.Lerp(transform.position, MouseCoords, 1f);
        print(MouseCoords);
    }
}
