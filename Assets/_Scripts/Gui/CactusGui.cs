using UnityEngine;

public class CactusGui : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private TMPro.TMP_Text cactusText;

    private void Awake()
    {
        cactusText = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        cactusText.text = gameController.CactusCount.ToString();
    }
}
