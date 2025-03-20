using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static int killCount = 0;

    [SerializeField] TMP_Text killCountText;

    void Start()
    {
        killCount = 0;
    }

    void Update()
    {
        killCountText.text = killCount.ToString();
    }
}
