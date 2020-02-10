using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    public Transform hand;
    public GameObject cookie1;
    public GameObject cookie2;
    public GameObject cookie3;

    private GameObject cookie;

    private Vector2 lookDirection;
    private float lookAngle;
    private void Start()
    {
        cookie = cookie1;
    }
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
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
        GameObject thrownCookie = Instantiate(cookie, hand.position, hand.rotation);
        thrownCookie.GetComponent<Rigidbody2D>().velocity = hand.up * 10f;
    }
}
