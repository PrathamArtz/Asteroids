using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    public int lives = 3;
    public float respawnTime = 3f;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayerDied()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke("Respawn", respawnTime);
        }
    }

    private void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collision");
        player.gameObject.SetActive(true);
        Invoke("TurnOnCollision", 2f);
    }

    private void TurnOnCollision()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
