using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public int DucksShot { get; private set; }
    public int DucksAttempted { get; private set; }

    public void DuckShot()
    {
        DucksShot++;
        DucksAttempted++;
    }

    public void DuckEscaped()
    {
        DucksAttempted++;
    }
}
