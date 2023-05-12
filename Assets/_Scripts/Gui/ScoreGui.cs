using UnityEngine;

public class ScoreGui : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private TMPro.TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = gameController.Score + "/200";
    }
}
