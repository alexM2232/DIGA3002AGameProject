using UnityEngine;

public class BackgroundClick : MonoBehaviour
{
    void OnMouseDown()
    {
        // Missed shot → consume bullet
        FindObjectOfType<BulletManager>().Shoot(false);
    }
}

