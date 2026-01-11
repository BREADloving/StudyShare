using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    public float jumpForce = 5f;
    private bool isGrounded=true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ) * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 地面に触れたら再ジャンプ可能にする（Planeなど）
        isGrounded = true;
    }

}