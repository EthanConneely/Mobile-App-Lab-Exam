using System.Collections.Generic;

using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CactusCount { get; set; } = 4;

    [SerializeField] private GameObject cactusPrefab;
    private Dictionary<Vector2Int, GameObject> gridCells = new();

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
}
