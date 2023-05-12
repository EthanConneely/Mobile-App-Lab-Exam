using System;
using System.Collections;

using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int score;
    [SerializeField] private float speed;
    private int health;

    private void Start()
    {
        health = maxHealth;

        Invoke(nameof(StartMoving), 2.05f);
    }

    private void StartMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    private void Update()
    {
        if (transform.position.x < -5.75f)
        {
            GameController.Instance.GameOver();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Needle"))
        {
            health -= GameController.Instance.Damage;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
                GameController.Instance.AddScore(score);
            }
        }

        if (other.CompareTag("Cactus"))
        {
            StartCoroutine(AttackCactus_Coroutine(other.gameObject));
        }
    }

    private IEnumerator AttackCactus_Coroutine(GameObject gameObject)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        GetComponentInChildren<Animator>().enabled = true;
    }
}
