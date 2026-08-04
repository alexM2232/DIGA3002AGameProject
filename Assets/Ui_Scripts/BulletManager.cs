using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Image[] bulletIcons;   // assign bullet UI images in Inspector
    public int bulletsPerRound = 3;
    private int bulletsRemaining;

    void Start()
    {
        ResetBullets();
    }

    public void ResetBullets()
    {
        bulletsRemaining = bulletsPerRound;
        for (int i = 0; i < bulletIcons.Length; i++)
        {
            bulletIcons[i].color = Color.white; // reset all bullets to white
        }
    }

    public void Shoot(bool hit)
    {
        if (bulletsRemaining <= 0) return;

        // mark the current bullet as used
        bulletIcons[bulletsPerRound - bulletsRemaining].color = Color.gray;
        bulletsRemaining--;

        if (bulletsRemaining <= 0 && !hit)
        {
            // Duck disappears immediately
            Duck duck = FindObjectOfType<Duck>();
            if (duck != null) Destroy(duck.gameObject);

            // Show escape panel + dog laugh
            UIManager ui = FindObjectOfType<UIManager>();
            ui.ShowBirdEscaped();

            FindObjectOfType<DuckManager>().DuckEscaped();
            FindObjectOfType<DogManager>().ShowDogLaugh();

            // End attempt immediately
            FindObjectOfType<GameManager>().EndDuckAttempt();
        }
    }
}
