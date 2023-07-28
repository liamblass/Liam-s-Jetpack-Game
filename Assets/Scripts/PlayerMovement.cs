using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float thrustForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject FlameFX;

    [SerializeField] private float paddingLeft, paddingRight;
    private Vector2 minBounds, maxBounds;

    private Rigidbody2D rb;
    private GameManager gm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        InitBounds();
    }

    private void Update()
    {
        if(gm.canThrust == true)
        {
            Thrust();
        }
        else
        {
            FlameFX.SetActive(false);
        }

        MoveOnX();
    }

    private void InitBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(Vector2.zero);
        maxBounds = Camera.main.ViewportToWorldPoint(Vector2.one);
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * thrustForce, ForceMode2D.Force);
            FlameFX.SetActive(true);
            gm.UseFuel();
        }
        else
        {
            FlameFX.SetActive(false);
        }
    }

    private void MoveOnX()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector2 newPosition = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,transform.position.y);
           newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
            transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
           Vector2 newPosition = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
           newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
            transform.position = newPosition;
        } 
    }    
}
