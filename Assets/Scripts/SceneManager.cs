using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
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