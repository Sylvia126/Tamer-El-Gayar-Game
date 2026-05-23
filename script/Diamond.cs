using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private int diamondValue = 1;
    private bool _isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollected) return;

        if (other.CompareTag(playerTag))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        _isCollected = true;

        // «” œ⁄«¡ “Ì«œ… «·‰ﬁ«ÿ „‰ „œÌ— «··⁄»… „»«‘—…
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddDiamond(diamondValue);
        }

        //  ‘€Ì· «·’Ê  „‰ ”ﬂ—Ì»  «··«⁄»
        PlayerAudio playerAudio = player.GetComponentInParent<PlayerAudio>();
        if (playerAudio != null)
        {
            playerAudio.PlayDiamondSound();
        }

        //  œ„Ì— «·ÃÊÂ—…
        Destroy(gameObject);
    }
}