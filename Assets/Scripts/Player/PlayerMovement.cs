using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] UnityEvent onDeath;
    Vector2 moveInput;
    float speed;

    public void MoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
       
        
    }
    private void Update()
    {
        Death();
    }
    private void FixedUpdate()
    {
        move();
    }
    void move()
    {
        rb.linearVelocity =  new Vector3(moveInput.x*speed, rb.linearVelocity.y, moveInput.y*speed);
    }

    public void SpeedData(float spd)
    {
       
        speed = spd*2f;
    }
    void Death()
    {
        if (transform.position.y < -1f)
        {
            onDeath?.Invoke();
        }
    }


}
