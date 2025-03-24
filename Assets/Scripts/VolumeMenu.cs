using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
    public CanvasGroup volumePanel;
    public CanvasGroup menuGroup;

    public void OpenVolume()
    {
        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;

        volumePanel.alpha = 1;
        volumePanel.interactable = true;
        volumePanel.blocksRaycasts = true;
    }

    public void CloseVolume()
    {
        volumePanel.alpha = 0;
        volumePanel.interactable = false;
        volumePanel.blocksRaycasts = false;

        menuGroup.alpha = 1;
        menuGroup.interactable = true;
        menuGroup.blocksRaycasts = true;
    }
}
