using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintQuizController : MonoBehaviour
{
    [Header("Hint Screen")]
    public GameObject HintScreen;
    public TextMeshProUGUI RememberText;
    public TextMeshProUGUI HintText;

    [Header("Quiz Screen")]
    public GameObject QuizScreen;
    public TextMeshProUGUI QuizQuestion;
    public Button AnswerButton_A;
    public Button AnswerButton_B;
    public Button AnswerButton_C;
    public Button AnswerButton_D;

    [Header("Upgrade Screen")]
    [SerializeField] private GameObject UpgradeScreen;

    private List<string> unansweredQuestions = new List<string>();
    private string currentQuestion;
    private Color normalColor;

    public void Awake()
    {
        foreach (string key in HintArray.hintDictionary.Keys)
            unansweredQuestions.Add(key);

        normalColor = AnswerButton_A.GetComponent<Image>().color;

        HintScreen.SetActive(false);
        QuizScreen.SetActive(false);
    }

    public void OnLevelUp()
    {
        if (unansweredQuestions.Count == 0)
        {
            Debug.Log("All questions answered!");
            return;
        }

        Time.timeScale = 0f;

        int randomIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomIndex];

        if (Random.Range(0f, 1f) < 0.5f)
            ActivateHintScreen(currentQuestion);
        else
            ActivateQuizScreen(currentQuestion);
    }

    private void ActivateHintScreen(string spørgsmål)
    {
        QuizScreen.SetActive(false);
        HintScreen.SetActive(true);
        HintText.text = HintArray.hintDictionary[spørgsmål][4];
        RememberText.text = "Hint!";
        StartCoroutine(HintTimer());
    }

    private IEnumerator HintTimer()
    {
        yield return new WaitForSecondsRealtime(10f);
        ResumeGame();
    }

    private void ActivateQuizScreen(string spørgsmål)
    {
        HintScreen.SetActive(false);
        QuizScreen.SetActive(true);

        // Make sure all quiz elements are visible
        QuizQuestion.gameObject.SetActive(true);
        AnswerButton_A.gameObject.SetActive(true);
        AnswerButton_B.gameObject.SetActive(true);
        AnswerButton_C.gameObject.SetActive(true);
        AnswerButton_D.gameObject.SetActive(true);

        // Reset button colors and interactivity
        SetButtonColor(AnswerButton_A, normalColor);
        SetButtonColor(AnswerButton_B, normalColor);
        SetButtonColor(AnswerButton_C, normalColor);
        SetButtonColor(AnswerButton_D, normalColor);

        AnswerButton_A.interactable = true;
        AnswerButton_B.interactable = true;
        AnswerButton_C.interactable = true;
        AnswerButton_D.interactable = true;

        string[] data = HintArray.hintDictionary[spørgsmål];
        QuizQuestion.text = spørgsmål;

        AnswerButton_A.GetComponentInChildren<TextMeshProUGUI>().text = data[0];
        AnswerButton_B.GetComponentInChildren<TextMeshProUGUI>().text = data[1];
        AnswerButton_C.GetComponentInChildren<TextMeshProUGUI>().text = data[2];
        AnswerButton_D.GetComponentInChildren<TextMeshProUGUI>().text = data[3];

        AnswerButton_A.onClick.RemoveAllListeners();
        AnswerButton_B.onClick.RemoveAllListeners();
        AnswerButton_C.onClick.RemoveAllListeners();
        AnswerButton_D.onClick.RemoveAllListeners();

        AnswerButton_A.onClick.AddListener(() => CheckAnswer(AnswerButton_A, data[0], spørgsmål));
        AnswerButton_B.onClick.AddListener(() => CheckAnswer(AnswerButton_B, data[1], spørgsmål));
        AnswerButton_C.onClick.AddListener(() => CheckAnswer(AnswerButton_C, data[2], spørgsmål));
        AnswerButton_D.onClick.AddListener(() => CheckAnswer(AnswerButton_D, data[3], spørgsmål));
    }

    private void CheckAnswer(Button pressedButton, string selectedAnswer, string spørgsmål)
    {
        AnswerButton_A.interactable = false;
        AnswerButton_B.interactable = false;
        AnswerButton_C.interactable = false;
        AnswerButton_D.interactable = false;

        string correctAnswer = GetCorrectAnswer(spørgsmål);
        Button correctButton = GetButtonByAnswer(correctAnswer, spørgsmål);

        if (selectedAnswer == correctAnswer)
        {
            SetButtonColor(pressedButton, new Color(0.4f, 0.8f, 0.4f));
            unansweredQuestions.Remove(spørgsmål);

            // Hide quiz elements but keep QuizScreen and background active
            QuizQuestion.gameObject.SetActive(false);
            AnswerButton_A.gameObject.SetActive(false);
            AnswerButton_B.gameObject.SetActive(false);
            AnswerButton_C.gameObject.SetActive(false);
            AnswerButton_D.gameObject.SetActive(false);

            UpgradeScreen.SetActive(true);
        }
        else
        {
            SetButtonColor(pressedButton, new Color(0.8f, 0.4f, 0.4f));
            if (correctButton != null)
                SetButtonColor(correctButton, new Color(0.4f, 0.8f, 0.4f));
            StartCoroutine(QuizResultTimer());
        }
    }

    private IEnumerator QuizResultTimer()
    {
        yield return new WaitForSecondsRealtime(5f);
        ResumeGame();
    }

    public void ResumeGame()
    {
        HintScreen.SetActive(false);
        QuizScreen.SetActive(false);
        UpgradeScreen.SetActive(false);

        // Re-enable quiz elements for next time
        QuizQuestion.gameObject.SetActive(true);
        AnswerButton_A.gameObject.SetActive(true);
        AnswerButton_B.gameObject.SetActive(true);
        AnswerButton_C.gameObject.SetActive(true);
        AnswerButton_D.gameObject.SetActive(true);

        AnswerButton_A.interactable = true;
        AnswerButton_B.interactable = true;
        AnswerButton_C.interactable = true;
        AnswerButton_D.interactable = true;

        Time.timeScale = 1f;
    }

    private void SetButtonColor(Button button, Color color)
    {
        button.GetComponent<Image>().color = color;
    }

    private Button GetButtonByAnswer(string answer, string spørgsmål)
    {
        string[] data = HintArray.hintDictionary[spørgsmål];
        if (data[0] == answer) return AnswerButton_A;
        if (data[1] == answer) return AnswerButton_B;
        if (data[2] == answer) return AnswerButton_C;
        if (data[3] == answer) return AnswerButton_D;
        return null;
    }

    private string GetCorrectAnswer(string spørgsmål)
    {
        foreach (var kvp in HintArray.quizDictionary)
        {
            if (kvp.Value == spørgsmål)
                return kvp.Key;
        }
        return "";
    }
}