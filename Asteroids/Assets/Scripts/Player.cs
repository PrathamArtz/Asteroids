using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed = 5;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        rb.transform.Translate(Vector2.up * verticalInput);
    }
}
