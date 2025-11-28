using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Vector2 moveInput;
   
   
    public void MoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
       
        
    }

    private void FixedUpdate()
    {
        move();
    }
    void move()
    {
        rb.linearVelocity = 10f * new Vector3(moveInput.x, rb.linearVelocity.y, moveInput.y);
    }

   
}
