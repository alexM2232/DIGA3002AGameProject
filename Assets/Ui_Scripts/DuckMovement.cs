using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float verticalSpeed = 3f;
    public float horizontalSpeed = 2f;
    private bool goingUp = true;
    private bool goingLeft;

    void Start()
    {
        goingUp = true;
        goingLeft = Random.value > 0.5f;
    }

    void Update()
    {
        if (goingUp)
        {
            transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
            if (transform.position.y > 3f) goingUp = false;
        }
        else
        {
            Vector2 direction = goingLeft ? Vector2.left : Vector2.right;
            transform.Translate(direction * horizontalSpeed * Time.deltaTime);
        }

        if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y > 6)
        {
            FindObjectOfType<GameManager>().DuckEscaped();
            Destroy(gameObject);
        }
    }
}
