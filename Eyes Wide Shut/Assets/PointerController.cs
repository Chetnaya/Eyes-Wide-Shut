using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 1f;
    private bool moveUp = true;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (moveUp)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }

        if (transform.position.y > startPos.y + distance)
        {
            moveUp = false;
        }
        else if (transform.position.y < startPos.y)
        {
            moveUp = true;
        }
    }
}
