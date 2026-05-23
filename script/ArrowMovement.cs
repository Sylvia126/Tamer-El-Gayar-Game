using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private Rigidbody rb;
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        // ... (your existing movement calculation code goes here) ...
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) { moveDirection += Vector3.forward; }
        if (Input.GetKey(KeyCode.DownArrow)) { moveDirection += Vector3.back; }
        if (Input.GetKey(KeyCode.LeftArrow)) { moveDirection += Vector3.left; }
        if (Input.GetKey(KeyCode.RightArrow)) { moveDirection += Vector3.right; }
        
        // Use the condition here to set the Animator parameter:
        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        rb.MovePosition(rb.position + moveDirection.normalized * movementSpeed * Time.deltaTime);
    }
    
    // You would use OnTriggerEnter/OnCollisionEnter to set the "isFalling" bool
    // animator.SetBool("isFalling", true); 
}
