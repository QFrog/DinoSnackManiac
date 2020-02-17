using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefController : MonoBehaviour
{
    public Transform target;
    Vector3 start;

    public float speed = 3;

    void Start()
    {
        //set the starting location to return to
        start = transform.position;
    }

    private void Update()
    {
        // remember, 10 - 5 is 5, so target - position is always your direction.
        Vector3 dir = target.position - transform.position;

        // magnitude is the total length of a vector.
        // getting the magnitude of the direction gives us the amount left to move
        float dist = dir.magnitude;

        // this makes the length of dir 1 so that you can multiply by it.
        dir = dir.normalized;

        // the amount we can move this frame
        float move = speed * Time.deltaTime;

        // limit our move to what we can travel.
        if (move > dist) move = dist;

        // apply the movement to the object.
        transform.Translate(dir * move);

        //reset position
        if(transform.position == target.position)
        {
            waiter();
            transform.position = start;
        }
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(4);
    }
}