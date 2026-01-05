using UnityEngine;

public class GoatMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private InputReaderSO inputReaderSO;
    private Rigidbody _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector2 input = inputReaderSO.Movement;

        Vector3 moveDir = new Vector3(input.x, 0f, input.y);

        _rigid.linearVelocity = new Vector3(
            moveDir.x * moveSpeed,
            _rigid.linearVelocity.y,
            moveDir.z * moveSpeed
        );
    }
}
