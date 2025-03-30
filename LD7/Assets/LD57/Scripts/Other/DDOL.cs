using UnityEngine;

public class DDOL : MonoBehaviour
{
    /// <summary>
    /// Added to make objects not destroy on load
    /// </summary>
    private void Awake()
    {
        if(gameObject != null)
            DontDestroyOnLoad(gameObject);
    }
}
