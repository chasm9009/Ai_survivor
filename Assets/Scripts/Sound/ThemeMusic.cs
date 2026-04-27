using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class ThemeMusic : MonoBehaviour
{
    [SerializeField] private EventReference themeEvent;
    [SerializeField] private string parameterName = "energy";
      private EventInstance instance;
    [Range(0f, 1f)]
    public float parameterValue;
    
    void Start()
    {
        instance = RuntimeManager.CreateInstance(themeEvent);
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        instance.setParameterByName(parameterName, parameterValue);
    }
     private void OnDestroy()
    {
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instance.release();
    }
}
