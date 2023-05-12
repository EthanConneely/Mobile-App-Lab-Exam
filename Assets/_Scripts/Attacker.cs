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
    }
}
