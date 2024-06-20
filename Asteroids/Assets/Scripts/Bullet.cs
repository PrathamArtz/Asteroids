using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    private Player player;
    public float speed = 500f;
    public float maxtime = 10.0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void Projectile(Vector2 target)
    {
        /* rb.AddForce(direction * speed);
         Destroy(gameObject, maxtime);*/
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed; // Directly setting velocity for accurate direction
        Destroy(gameObject, maxtime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
