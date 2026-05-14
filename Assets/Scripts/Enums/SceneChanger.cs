using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject Introscene;
    public GameObject mainScene;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
    
    }
    public void ChangeScene(GameObject nameOfPanel)
    {
        // Deactivate all panels
        Introscene.SetActive(false);
        mainScene.SetActive(false);
        // Activate the specified panel
        nameOfPanel.SetActive(true);
    }
}   
