using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Image[] bulletIcons; // assign BulletIcon1–3 in Inspector
    public int BulletsLeft { get; private set; }

    void Start()
    {
        ResetBullets();
    }

    public void Shoot(bool hitDuck)
    {
        if (BulletsLeft > 0)
        {
            BulletsLeft--;
            bulletIcons[BulletsLeft].enabled = false;

            if (hitDuck)
            {
                // Reset bullets back to 3 after a successful hit
                ResetBullets();
            }
        }
        else
        {
            // No bullets left → bird flew away
            FindObjectOfType<UIManager>().ShowBirdEscaped();
        }
    }

    public void ResetBullets()
    {
        BulletsLeft = bulletIcons.Length;
        foreach (Image icon in bulletIcons)
        {
            icon.enabled = true;
        }
    }
}
