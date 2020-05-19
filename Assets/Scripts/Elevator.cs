using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float max;
    public int up;
    public float speed;

    void Start()
    {
        up = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection;

        if ((transform.position.y < max && up == 1) || transform.position.y <= 0)
        {
            up = 1;
            moveDirection = Vector3.up;
        }
        else
        {
            up = 0;
            moveDirection = Vector3.down;
        }

        transform.Translate(moveDirection * Time.deltaTime * speed);
    }
}
