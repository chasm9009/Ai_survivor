using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI xpText;
    [SerializeField] Image xpImage;

    [Space(10)]
    [Header("XP Sprites")]
    [SerializeField] Sprite xp0;
    [SerializeField] Sprite xp25;
    [SerializeField] Sprite xp50;
    [SerializeField] Sprite xp75;
    [SerializeField] Sprite xp100;

    [Space(10)]
    [Header("Score Settings")]
    [SerializeField] int targetXP = 100;
    [SerializeField] int targetXPIncrease = 25;

    int currentLevel = 1;
    int currentXP = 0;
    bool showFullXP = false;

    void Start()
    {
        UpdateHUD();
    }

    public void IncreaseXP(int amount)
    {
        currentXP += amount;
        showFullXP = currentXP >= targetXP;
        CheckForLevelUp();
        UpdateHUD();
    }

    private void CheckForLevelUp()
    {
        if(currentXP >= targetXP)
        {
            currentXP -= targetXP;
            currentLevel++;
            targetXP += targetXPIncrease;
        }
    }

    private void UpdateHUD()
    {
        if (currentLevelText)
            currentLevelText.text = "Level: " + currentLevel;

        if (xpText)
            xpText.text = currentXP + " / " + targetXP;

        UpdateXPBar();
    }

    private void UpdateXPBar()
    {
        if (showFullXP)
        {
            xpImage.sprite = xp100;
            showFullXP = false;
            return;
        }

        float progress = (float)currentXP / targetXP;

        if (progress >= 1f)
            xpImage.sprite = xp100;
        else if (progress >= 0.75f)
            xpImage.sprite = xp75;
        else if (progress >= 0.5f)
            xpImage.sprite = xp50;
        else if (progress >= 0.25f)
            xpImage.sprite = xp25;
        else
            xpImage.sprite = xp0;
    }
}
