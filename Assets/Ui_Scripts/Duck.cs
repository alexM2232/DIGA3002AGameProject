using UnityEngine;

public class Duck : MonoBehaviour
{
    private bool isHit = false;

    void OnMouseDown()
    {
        if (isHit) return;
        isHit = true;

        FindObjectOfType<DuckManager>().DuckShot(); // red icon
        FindObjectOfType<BulletManager>().Shoot(true);

        UIManager ui = FindObjectOfType<UIManager>();
        ui.ShowRoundResult(true);

        FindObjectOfType<DogManager>().ShowDogWithDuck(); // placeholder

        Destroy(gameObject);
        FindObjectOfType<GameManager>().EndDuckAttempt();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EscapeZone"))
        {
            FindObjectOfType<DuckManager>().DuckEscaped(); // gray icon
            UIManager ui = FindObjectOfType<UIManager>();
            ui.ShowBirdEscaped();

            FindObjectOfType<DogManager>().ShowDogLaugh(); // placeholder

            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndDuckAttempt();
        }
    }
}
