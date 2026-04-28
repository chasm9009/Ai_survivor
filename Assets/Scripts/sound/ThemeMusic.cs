using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class ThemeMusic : MonoBehaviour
{
    [SerializeField] private EventReference themeEvent;
    [SerializeField] private string parameterName = "energy";
      private EventInstance instance;
    [Range(0f, 1f)]
    public float currentEnergy;
    public float volume = 1f;
    public float lowHealth;
    
    void Start()
    {
        instance = RuntimeManager.CreateInstance(themeEvent);
        instance.start();
        instance.setParameterByName("themeVolume", volume);
    }

    public void SetEnergy(float value)
    {
        currentEnergy = Mathf.Lerp(currentEnergy, value, Time.deltaTime * 2f);
        instance.setParameterByName("Energy", currentEnergy);
    }
     public void StartRinging(float value)
    {
        lowHealth = Mathf.Lerp(lowHealth, value, Time.deltaTime * 2f);
        instance.setParameterByName("lowLife", lowHealth);
    }
  

    // Update is called once per frame
    void Update()
    {
        instance.setParameterByName(parameterName, currentEnergy);
        instance.setParameterByName("themeVolume", volume);
    }
     private void OnDestroy()
    {
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instance.release();
    }
}
