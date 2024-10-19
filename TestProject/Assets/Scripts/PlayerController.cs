using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _followDistance = 3.5f;
    [SerializeField]
    private float _rayDistance = 5f; 
    public GameObject currentItem;
    private bool _isHoldingItem = false;
    private NotificationManager _notificationManager;
    private Camera _playerCamera;

    private void Start()
    {
        _notificationManager = FindAnyObjectByType<NotificationManager>();
        _playerCamera = Camera.main;
    }
    void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        CheckForItem();

    }
    void CheckForItem()
    {
        if (_isHoldingItem) return;
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            if (hit.collider.CompareTag("Item")) 
            {
                currentItem = hit.collider.gameObject; 
                ShowPickupMessage(); 
            }
            else
            {
                HidePickupMessage();
                currentItem = null; 
            }
        }
        else
        {
            HidePickupMessage();
            currentItem = null;
        }
    }

    void ShowPickupMessage()
    {
        _notificationManager.ShowPickUpNotification("Pickup item - E");
    }
    void HidePickupMessage()
    {
        _notificationManager.HidePickUpNotification();

    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isHoldingItem) 
            {
                StopHoldingItem();
            }
            else if (currentItem != null) 
            {
                StartHoldingItem();
            }
        }

        if (_isHoldingItem)
        {
            FollowCursor();
        }
    }

    void StartHoldingItem()
    {
        HidePickupMessage();
        _isHoldingItem = true;
        currentItem.GetComponent<Rigidbody>().useGravity = false;
        currentItem.transform.SetParent(this.transform); 
    }

    void StopHoldingItem()
    {
        _isHoldingItem = false;
        currentItem.GetComponent<Rigidbody>().useGravity = true;

        currentItem.transform.SetParent(null); 
    }

    void FollowCursor()
    {
        Vector3 direction = _playerCamera.transform.forward;
        Vector3 targetPosition = _playerCamera.transform.position + direction.normalized * _followDistance;
        currentItem.transform.position = Vector3.Lerp(currentItem.transform.position, targetPosition, Time.deltaTime * 10f);
    }
}
