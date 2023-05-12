using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
