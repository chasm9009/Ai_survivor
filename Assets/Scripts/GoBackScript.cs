using UnityEngine;
public class GoBackButton : MonoBehaviour
{
    public GameObject settingsMenu; // drag your Panel here in Inspector

    public void ResumeGame()
    {
        settingsMenu.SetActive(false); // hide menu
        Time.timeScale = 1f; // resume game
    }
}
