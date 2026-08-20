using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
        public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.TriggerGameOver();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.TriggerLevelComplete();
        }
    }
}
