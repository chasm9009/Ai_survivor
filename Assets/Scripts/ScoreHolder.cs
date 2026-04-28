using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currentLevelText;
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
    bool showFullXP = false;
    public void UpdateXPBar(int currentLevel, float currentXp = -1, float targetXp = -1)
    {
        if (showFullXP)
        {
            xpImage.sprite = xp100;
            showFullXP = false;
            return;
        }

        float progress = (float)currentXp / targetXp;

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

        currentLevelText.text = "Level " + currentLevel;
    }
}
