using UnityEngine;
using static Define;

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
            Target target = hit.collider.gameObject.GetComponent<Target>();

            if (hit.collider.CompareTag(Tags.Target))
            {
                StartCoroutine(target.Catched());
            }
        }
    }
}