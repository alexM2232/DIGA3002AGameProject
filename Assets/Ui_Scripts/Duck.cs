using UnityEngine;

public class Duck : MonoBehaviour
{
    private bool isHit = false;

    [Header("Audio")]
    public AudioSource duckHitAudio; // 🎵 assign in prefab

    void OnMouseDown()
    {
        if (isHit) return;
        isHit = true;

        // Play duck hit sound
        if (duckHitAudio != null)
        {
            duckHitAudio.Play();
        }

        FindObjectOfType<GameManager>().DuckShot();

        // Delay destroy slightly so sound can play
        Destroy(gameObject, 0.2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EscapeZone"))
        {
            FindObjectOfType<GameManager>().DuckEscaped();
            Destroy(gameObject);
        }
    }
}
