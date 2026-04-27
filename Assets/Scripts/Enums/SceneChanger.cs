using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject Introscene;
    public GameObject mainScene;

    public void StartMainScene()
    {
        ChangeScene(mainScene);
    }

    public void ShowIntroScene()
    {
        ChangeScene(Introscene);
    }

    public void ChangeScene(GameObject panelToActivate)
 {
        if (Introscene != null)
            Introscene.SetActive(false);

        if (mainScene != null)
            mainScene.SetActive(false);

        if (panelToActivate != null)
            panelToActivate.SetActive(true);
    }
}   
