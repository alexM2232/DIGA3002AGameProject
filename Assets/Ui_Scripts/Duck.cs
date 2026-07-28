using UnityEngine;

public class Duck : MonoBehaviour
{
    void OnMouseDown()
    {
        // Duck was clicked → hit
        FindObjectOfType<DuckManager>().DuckHit();
        FindObjectOfType<BulletManager>().Shoot(true);

        // Optionally destroy duck sprite after hit
        Destroy(gameObject);
    }
}


