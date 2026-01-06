using UnityEngine;

public class ObjectTransparent : MonoBehaviour
{
    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            //hitInfo.collider.gameObject.GetComponent<Rend>
        }
    }
}
