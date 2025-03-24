using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSound;

    private static AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
        {
            GameObject audioObj = GameObject.Find("UIButtonAudio");
            if (audioObj != null)
                audioSource = audioObj.GetComponent<AudioSource>();
        }

        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
            audioSource.PlayOneShot(clickSound);
    }
}
