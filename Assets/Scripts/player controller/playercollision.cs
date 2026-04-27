using System.Collections;
using UnityEngine;

public class playercollision : MonoBehaviour
{
public SpriteRenderer sr;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Player started at position: " + transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
            Debug.Log("Player collided with an enemy!");
             StartCoroutine(FlashRed());
    }

    IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}