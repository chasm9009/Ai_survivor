using UnityEngine;
using FMODUnity;


public class BulletSound : MonoBehaviour
{
    public BulletSound Instance;
     [SerializeField] private EventReference pistolShot;
  private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void PlayBang()
    {
        RuntimeManager.PlayOneShot(pistolShot);
    }
}
