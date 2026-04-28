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

    [Header("Elon")]
    [SerializeField] private EventReference elonQuotes;
    [SerializeField] private EventReference elonDeath;

    [Header("Mark")]
    [SerializeField] private EventReference markQuotes;
    [SerializeField] private EventReference markDeath;

    [SerializeField] private EventReference elonIntro;

    private EventInstance elonQuotesInstance;
    private EventInstance markQuotesInstance;

    private void Awake()
    {
        Instance = this;
        elonQuotesInstance = RuntimeManager.CreateInstance(elonQuotes);
        markQuotesInstance = RuntimeManager.CreateInstance(markQuotes);
    }

    public void PlayPlayerDeath()
    {
        RuntimeManager.PlayOneShot(playerDeath);
    }
        public void ElonIntro()
    {
        RuntimeManager.PlayOneShot(elonIntro);
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

    // ================================
    // ELON
    // ================================

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

    // ================================
    // MARK
    // ================================

    public void PlayMarkQuotes()
    {
        markQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        markQuotesInstance.start();
    }

    public void StopMarkQuotes()
    {
        markQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void PlayMarkDeath()
    {
        RuntimeManager.PlayOneShot(markDeath);
    }

    // ================================
    // CLEANUP
    // ================================

    private void OnDestroy()
    {
        elonQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        elonQuotesInstance.release();

        markQuotesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        markQuotesInstance.release();
    }
}