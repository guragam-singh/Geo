using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Vector2 cameraOffset;
    public float interpolationTime = 0.1f;
    public float lookAhead = 4f;
    public Transform player;

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null)
        {
            return;
        }

        Vector3 targetPosition = new Vector3(
            player.position.x + cameraOffset.x + lookAhead,
            player.position.y + cameraOffset.y,
            transform.position.z);

        float smoothing = 1f - Mathf.Exp(-Time.deltaTime / Mathf.Max(interpolationTime, 0.01f));
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    }
}
