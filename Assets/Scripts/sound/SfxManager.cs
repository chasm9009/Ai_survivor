using UnityEngine;
using FMODUnity;
public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;
    [SerializeField] private EventReference playerDeath;
    [SerializeField] private EventReference enemyDeath;
    [SerializeField] private EventReference bossDeath;
    [SerializeField] private EventReference levelUp;
    [SerializeField] private EventReference hoverButton;
   
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void PlayPlayerDeath()
    {
        RuntimeManager.PlayOneShot(playerDeath);
    }

    public void PlayEnemyDeath()
    {
        RuntimeManager.PlayOneShot(enemyDeath);
    }

    public void PlayLevelUp()
    {
        RuntimeManager.PlayOneShot(levelUp);
    }

    public void PlayHoverButton()
    {
        RuntimeManager.PlayOneShot(hoverButton);
    }
    public void playBossDeath()
    {
        RuntimeManager.PlayOneShot(bossDeath);
    }
}

    

