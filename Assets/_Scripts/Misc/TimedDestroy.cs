using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
