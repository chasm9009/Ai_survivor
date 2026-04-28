using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;


public class BulletSound : MonoBehaviour
{
    public static BulletSound Instance;
    [SerializeField] private EventReference pistolShot;
    [SerializeField] private EventReference energyShock;
    [SerializeField] private EventReference knifeSwing;
    WeaponHandler weaponHandler;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void PlayBang()
    {
        if (weaponHandler.currentWeapons.Count == 0)
        {
            RuntimeManager.PlayOneShot(pistolShot);
        }
        else if (weaponHandler.currentWeapons.Count == 1)
        {
            RuntimeManager.PlayOneShot(energyShock);
        }
         else if (weaponHandler.currentWeapons.Count == 2)
        {
            RuntimeManager.PlayOneShot(pistolShot);
        }
         else if (weaponHandler.currentWeapons.Count == 3)
        {
            RuntimeManager.PlayOneShot(knifeSwing);
        }
    }
/*
    public void PlayEnergyShock()
    {
        RuntimeManager.PlayOneShot(energyShock);
    }
    public void PlayKnifeSwing()
    {
        RuntimeManager.PlayOneShot(knifeSwing);
    }
*/
}
