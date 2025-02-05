using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform firePos;
    private Vector3 dir;
    private Ray ray;

    public float rayDistance = 100f;
    public LayerMask hitLayer;

    private void Start()
    {
        firePos = GameObject.Find("Player/FirePos").transform;
    }

    private void Update()
    {
        dir = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
        ray = new Ray(firePos.position, dir);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, hitLayer))
        {
            Debug.Log($"Hit: {hit.collider.name}");

            if (hit.collider.CompareTag("Target"))
            {
                Debug.Log("Target Hit");
            }
        }
    }
}