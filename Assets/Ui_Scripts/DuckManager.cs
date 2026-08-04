using UnityEngine;
using UnityEngine.UI;

public class DuckManager : MonoBehaviour
{
    public Image[] duckIcons;
    public int DucksAttempted { get; private set; }
    public int TotalDucks => duckIcons.Length;

    public void DuckShot()
    {
        if (DucksAttempted < duckIcons.Length)
        {
            duckIcons[DucksAttempted].color = Color.red; // shot = red
            DucksAttempted++;
        }
    }

    public void DuckEscaped()
    {
        if (DucksAttempted < duckIcons.Length)
        {
            duckIcons[DucksAttempted].color = Color.gray; // escape = gray
            DucksAttempted++;
        }
    }

    public void ResetDucks()
    {
        DucksAttempted = 0;
        foreach (Image icon in duckIcons)
        {
            icon.color = Color.white;
        }
    }
}

