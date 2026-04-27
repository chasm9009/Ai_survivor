using UnityEngine;

public class playercollision : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Player started at position: " + transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
            Debug.Log("Player collided with an enemy!");
    }
}