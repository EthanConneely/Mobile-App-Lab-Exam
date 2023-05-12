using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager I;

    public int Score { get; private set; }

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        Score += 1;
    }
}
