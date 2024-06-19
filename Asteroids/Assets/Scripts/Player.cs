using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    private float playerSpeed = 3;
    private Rigidbody2D rb;
    private Camera cam;

    Vector2 mousepos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }


    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(Vector2.up * verticalInput);

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position,transform.rotation);
        bullet.Projectile(mousepos);
    }
}
