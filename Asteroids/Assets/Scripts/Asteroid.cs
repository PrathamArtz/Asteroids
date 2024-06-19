using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    public float size = 1f;
    public float minsize = 0.5f;
    public float maxsize = 1.5f;
    public float speed = 50.0f;
    public float maxLifetime = 30f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0.0f , 0.0f , Random.value * 360.0f); //This line sets a random rotation around the z-axis (since it's a 2D game) for the asteroid.
        transform.localScale = Vector3.one * size; //This line scales the asteroid uniformly based on the size value. Vector3.one is a shorthand for new Vector3(1, 1, 1).

        _rigidbody2D.mass = size; //This line sets the mass of the asteroid's Rigidbody2D to match its size, which is important for physics calculations like collisions and momentum.
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * speed);
        Destroy(gameObject, maxLifetime);
    }
}
