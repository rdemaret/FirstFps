using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private PlayerWeapon weapon = new PlayerWeapon();

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("No camera assigned");
            this.enabled = false;
        }    
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.getRange(), mask ))
        {
            Debug.Log($"you touch something... {hit.collider.name}");
        }
    }
}
