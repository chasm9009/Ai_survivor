using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private Image xpImage;

    [Space(10)]
    [Header("XP Sprites")]
    [SerializeField] private Sprite[] xpSprites; // array i stedet for individuelle sprites for hver xp level

    [Space(10)]
    [Header("Score Settings")]
    [SerializeField] int targetXP = 100;
    [SerializeField] int targetXPIncrease = 25;
    bool showFullXP = false;
    public void UpdateXPBar(int currentLevel, float currentXp, float targetXp)
    {
        if (xpImage == null || xpSprites.Length == 0)
            return;

        float progress = (float)currentXp / targetXp;

        int spriteIndex = GetXPIndex(progress);

        xpImage.sprite = xpSprites[spriteIndex];

        currentLevelText.text = "Level: " + currentLevel;
    }

    private int GetXPIndex(float progress)
    {
        if (progress >= 1f)
            return 4; 
        else if (progress >= 0.75f)
            return 3; 
        else if (progress >= 0.5f)
            return 2; 
        else if (progress >= 0.25f)
            return 1; 
        else
            return 0;
    }
}
