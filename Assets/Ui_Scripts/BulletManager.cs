using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Image[] bulletIcons;
    public int bulletsPerRound = 3;
    private int bulletsRemaining;

    [Header("Audio")]
    public AudioSource gunshotAudio; // 🔫 add audio source

    void Start()
    {
        ResetBullets();
    }

    public void ResetBullets()
    {
        bulletsRemaining = bulletsPerRound;
        for (int i = 0; i < bulletIcons.Length; i++)
        {
            bulletIcons[i].color = Color.white;
        }
    }

    public void Shoot(bool hit)
    {
        if (bulletsRemaining <= 0) return;

        // 🔫 Play gunshot sound whenever a bullet is fired
        if (gunshotAudio != null)
        {
            gunshotAudio.Play();
        }

        bulletIcons[bulletsPerRound - bulletsRemaining].color = Color.gray;
        bulletsRemaining--;

        if (hit)
        {
            // Notify GameManager of a shot
            FindObjectOfType<GameManager>().DuckShot();
        }
        else if (bulletsRemaining <= 0)
        {
            // Notify GameManager of escape when bullets run out
            FindObjectOfType<GameManager>().DuckEscaped();
        }
    }
}
