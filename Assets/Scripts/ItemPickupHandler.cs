using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupHandler : MonoBehaviour
{
    float pickupRange = 2f;
    int pickupLayerMask;
    [SerializeField] 
    Camera mainCamera;

    Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        pickupLayerMask = LayerMask.GetMask("Pickup");
    }
    

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange, pickupLayerMask))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.TryGetComponent<InventoryObject>(out InventoryObject item))
            {
                item.OnHandlePickupItem();                
                Debug.Log("Picking up an object");
            }
        }
    }
}
