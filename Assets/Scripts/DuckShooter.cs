using UnityEngine;
using UnityEngine.UI;

public class DuckShooter : MonoBehaviour
{
    public GameObject hitEffect; // Particle effect or "Well Done" sprite
    public Text scoreText;       // Reference to your UI Score text
    private int score = 0;

    void Update()
    {
        // 1. Detect left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // 2. Cast a ray from camera to mouse position
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            // 3. Check if we hit a duck
            if (hit.collider != null && hit.collider.CompareTag("Duck"))
            {
                // Play particle effect at the hit location
                if (hitEffect != null)
                {
                    Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
                }

                // Destroy the duck
                Destroy(hit.collider.gameObject);

                // Update the score
                score++;
                if (scoreText != null)
                {
                    scoreText.text = "Score: " + score;
                }
            }
        }
    }
}
