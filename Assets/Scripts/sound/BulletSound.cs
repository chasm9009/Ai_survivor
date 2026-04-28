using UnityEngine;
using FMODUnity;


public class BulletSound : MonoBehaviour
{
    public static BulletSound Instance;
    [SerializeField] private EventReference pistolShot;
    [SerializeField] private EventReference energyShock;
    [SerializeField] private EventReference knifeSwing;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void PlayBang()
    {
        RuntimeManager.PlayOneShot(pistolShot);
    }

    public void PlayEnergyShock()
    {
        RuntimeManager.PlayOneShot(energyShock);
    }
    public void PlayKnifeSwing()
    {
        RuntimeManager.PlayOneShot(knifeSwing);
    }
}
