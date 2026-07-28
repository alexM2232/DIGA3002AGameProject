using UnityEngine;
using UnityEngine.UI;

public class DuckManager : MonoBehaviour
{
    public Image[] duckIcons; // assign DuckPanel1–10 in Inspector
    public int DucksShot { get; private set; }
    public int TotalDucks => duckIcons.Length;

    public void DuckHit()
    {
        if (DucksShot < duckIcons.Length)
        {
            duckIcons[DucksShot].color = Color.red; // tint red
            DucksShot++;
        }
    }

    public void ResetDucks()
    {
        DucksShot = 0;
        foreach (Image icon in duckIcons)
        {
            icon.color = Color.white; // reset to normal
        }
    }
}
