using UnityEngine;

public class GoatRotation : MonoBehaviour
{
    private Camera mainCam;
    private Rigidbody rigid;

    Vector3 dir;

    void Awake()
    {
        mainCam = Camera.main;
        rigid = GetComponent<Rigidbody>();

        ray = mainCam.ScreenPointToRay(Input.mousePosition);
    }

    Ray ray;

    private void Update() // 레이케스트
    {
        ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            dir = hit.point - transform.position;
            dir = dir.normalized;
            dir.y = 0f;
        }

        //dir = Random.insideUnitCircle.normalized;

    }

    void FixedUpdate() // 실제 물리연산
    {
        if (dir.sqrMagnitude > 0.01f)
        {
            Quaternion target = Quaternion.LookRotation(dir);
            if (Quaternion.Angle(rigid.rotation, target) > 0.5f)
            {
                rigid.MoveRotation(target);
            }
        }
    }
}
