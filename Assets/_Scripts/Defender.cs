using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    public void Shoot()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
    }
}
