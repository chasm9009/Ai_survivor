using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
  private Rigidbody rb;
  [SerializeField] private float speed = 5f;
  [SerializeField] public InputActionReference moveInput;
  [SerializeField] private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
      Vector2 moveDirection = moveInput.action.ReadValue<Vector2>();
      transform.Translate(new Vector2(moveDirection.x, moveDirection.y) * speed * Time.deltaTime);

       if (moveDirection.x < 0)
    {
        spriteRenderer.flipX = true;
    }
    else if (moveDirection.x > 0)
    {
        spriteRenderer.flipX = false;
    }
    }
}
