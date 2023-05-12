using System.Collections.Generic;

using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public int CactusCount { get; set; } = 4;
    public int Score { get; private set; }
    public int Damage { get; private set; } = 1;

    [SerializeField] private GameObject cactusPrefab;
    private Dictionary<Vector2Int, GameObject> gridCells = new();

    private void Awake()
    {
        Instance = this;
    }

    private void OnMouseDown()
    {
        Vector2 mousePosition = Input.mousePosition;

        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2Int gridPosition = new(Mathf.RoundToInt(worldMousePosition.x), Mathf.RoundToInt(worldMousePosition.y));

        // Only place a cactus in an empty cell and have cacti left to place
        if (!gridCells.ContainsKey(gridPosition) && CactusCount > 0)
        {
            GameObject cactus = Instantiate(cactusPrefab, (Vector2)gridPosition, Quaternion.identity, transform);
            gridCells.Add(gridPosition, cactus);
            CactusCount--;
        }
    }

    public void AddScore(int score)
    {
        Score += score;

        if (Score >= 200)
        {
            Debug.Log("You win!");
        }

        if (Score >= 100)
        {
            Damage = 3;
        }
        else if (Score >= 60)
        {
            Damage = 2;
        }
    }
}
