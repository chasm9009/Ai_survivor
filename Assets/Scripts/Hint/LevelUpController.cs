using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    public TextMeshProUGUI RememberText;
    public TextMeshProUGUI HintText; 
    public TextMeshProUGUI QuizQuestion;
    public GameObject HintBackground;
    
    private void ActivateHintScreen(string spørgsmål)
    {
        HintBackground.gameObject.SetActive(true);
        RememberText.gameObject.SetActive(true);
        HintText.gameObject.SetActive(true);
        ShowHint(spørgsmål);
    }

    void ShowHint(string spørgsmål)
    {
        HintText.text = HintArray.hintDictionary[spørgsmål][4];
    }
    
    void OnLevelUp()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
