using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton ·Ã⁄· «·Ê’Ê· ··”ﬂ—»  ”Â·« „‰ √Ì „ﬂ«‰
    public static GameManager Instance;

    public TMP_Text scoreText;
    private int _diamondCounter = 0;

    private void Awake()
    {
        // «· √ﬂœ „‰ ÊÃÊœ ‰”Œ… Ê«Õœ… ›ﬁÿ „‰ «·„œÌ—
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddDiamond(int amount)
    {
        _diamondCounter += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "btngan: " + _diamondCounter;
        }
    }
}