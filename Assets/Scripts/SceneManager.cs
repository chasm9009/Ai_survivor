using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{ 

    public void ChangeScene(string sceneName)
    {
        if(SfxManager.Instance != null)
        {
            SfxManager.Instance.StopElonIntro();
        }
    
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}