using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    bool facingRight = true;
    private Rigidbody2D rb2d;
    private SpriteRenderer dino;
    public SpriteRenderer hand;
    public Vector3 playerLocation; //I'm using this for enemy tracking
    Vector3 change;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dino = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        playerLocation = transform.position;
        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player
            dino.flipX = true; // activate look right some other way
            hand.flipX = true;
            facingRight = true;
        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
            dino.flipX = false; // activate look right some other way
            hand.flipX = false;
            // activate looking left
            facingRight = false;
        }
    }
    void FixedUpdate()
    {
        float moveHorizontonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontonal, moveVertical);
        rb2d.velocity = movement* speed;
    }

}
