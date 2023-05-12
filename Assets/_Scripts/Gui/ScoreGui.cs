using UnityEngine;

public class ScoreGui : MonoBehaviour
{
    private TMPro.TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = ScoreManager.I.Score + "/200";
    }
}
