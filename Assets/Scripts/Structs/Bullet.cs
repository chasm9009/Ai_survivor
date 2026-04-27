using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletTypes bulletType;
    public int damage;
    public float range;

    public float distanceTraveled;
    public float speed;
    public Sprite sprite;
    public Vector2 direction;
}
