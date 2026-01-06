using System.Collections;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float coolTime = 1f;
    private Material mat;
    private bool isActivate = true;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void SetAlpha(float val)
    {
        Color cor = mat.color;
        cor.a = val;
        mat.color = cor;
    }

    private IEnumerator CoolTime()
    {
        SetAlpha(0.4f);
        yield return new WaitForSeconds(coolTime);
        SetAlpha(1);

        isActivate = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isActivate) return;

        if (other.gameObject.CompareTag("Goat"))
        {
            if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rigid))
            {
                Vector3 velocity = rigid.linearVelocity;
                velocity.y = 0f;
                rigid.linearVelocity = velocity;

                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            if (other.gameObject.transform.GetChild(0).TryGetComponent<Animator>(out Animator animator))
            {
                animator.SetTrigger("Jump");
            }

            isActivate = false;
            StartCoroutine(CoolTime());
        }
    }
}
