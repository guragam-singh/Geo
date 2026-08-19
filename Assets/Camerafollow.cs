using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset= new Vector3(0f, 0f, -10f);

    void LateUpdate()
    {
        if (player == null) return ;
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
