using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    [SerializeField] private EventReference playerDeath;
    [SerializeField] private EventReference enemyDeath;
    [SerializeField] private EventReference bossDeath;
    [SerializeField] private EventReference levelUp;
    [SerializeField] private EventReference hoverButton;
    [SerializeField] private EventReference elonQuotes;
    [SerializeField] private EventReference elonDeath;

    private EventInstance elonQuotesInstance;

    private void Awake()
    {
        Instance = this;
        elonQuotesInstance = RuntimeManager.CreateInstance(elonQuotes);
    }

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

    public void PlayBossDeath()
    {
        RuntimeManager.PlayOneShot(bossDeath);
    }

    public void PlayElonQuotes()
    {
        elonQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        elonQuotesInstance.start();
    }

    public void StopElonQuotes()
    {
        elonQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void PlayElonDeath()
    {
        RuntimeManager.PlayOneShot(elonDeath);
    }

    private void OnDestroy()
    {
        elonQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        elonQuotesInstance.release();
    }
}