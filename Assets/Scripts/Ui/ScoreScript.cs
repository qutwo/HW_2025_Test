using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject deathScreen;
    int score = 0;

    void Start()
    {
        // Initialize score display
        UpdateScoreDisplay();
    }

    public void Scored()
    {
        score++;
        
        UpdateScoreDisplay();
        PlayScorePunchAnimation();
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void PlayScorePunchAnimation()
    {
        if (scoreText != null)
        {
            // Kill any existing animations
            scoreText.transform.DOKill();

            // Punch scale animation with bounce effect
            scoreText.transform.DOPunchScale(Vector3.one * 0.3f, 0.15f, 3, 0.2f)
                .SetEase(Ease.OutQuad);
        }
    }
    public void OnDeath()
    {
        deathScreen.SetActive(true);
    }
}