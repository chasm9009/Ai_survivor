using UnityEngine;
using FMODUnity;
using System;



public class BulletSound : MonoBehaviour
{
   
    [Header("Bullet Sounds")]
    [SerializeField] private EventReference pistolShot;
    [SerializeField] private EventReference energyShock;
    [SerializeField] private EventReference knifeSwing;

   

     private void OnEnable()
    {
        BulletHandler.OnPistolShot += PlayPistolShot;
        BulletHandler.OnKnifeSwing += PlayKnifeSwing;
        BulletHandler.OnEnergyShot += PlayEnergyShot;
    }

    private void OnDisable()
    {
        BulletHandler.OnPistolShot -= PlayPistolShot;
        BulletHandler.OnKnifeSwing -= PlayKnifeSwing;
        BulletHandler.OnEnergyShot -= PlayEnergyShot;
    }

    private void PlayPistolShot()
    {
        RuntimeManager.PlayOneShot(pistolShot);
    }

    private void PlayEnergyShot()
    {
        RuntimeManager.PlayOneShot(energyShock);
    }

    private void PlayKnifeSwing()
    {
        RuntimeManager.PlayOneShot(knifeSwing);
    }

}

