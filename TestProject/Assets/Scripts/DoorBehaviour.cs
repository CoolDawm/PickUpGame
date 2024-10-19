using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Animator _animator;
    private NotificationManager _notificationManager;
    private bool _isInteracteble;
    private bool _isOpen=false;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _notificationManager = FindAnyObjectByType<NotificationManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _isInteracteble = true;
        if (!_isOpen)
        {
            _notificationManager.ShowInteractNotification("Open Door - F");

        }
        else
        {
            _notificationManager.ShowInteractNotification("Close Door - F");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        _isInteracteble = false;
        _notificationManager.HideInteractNotification();
    }
    void Update()
    {
        if (!_isInteracteble) return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetTrigger("IsInteracted");
            _isOpen =!_isOpen;

        }
    }
}
