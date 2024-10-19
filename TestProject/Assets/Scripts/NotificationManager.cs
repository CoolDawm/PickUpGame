using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _pickupNotifText;
    [SerializeField]
    private TextMeshProUGUI _interactNotifText;
    public void ShowPickUpNotification(string text)
    {
        if (_pickupNotifText.text == "")
        {
            _pickupNotifText.text= text;
        }
    }
    public void HidePickUpNotification()
    {
        _pickupNotifText.text = "";
    }
    public void ShowInteractNotification(string text)
    {
        if (_interactNotifText.text == "")
        {
            _interactNotifText.text = text;
        }
    }
    public void HideInteractNotification()
    {
        _interactNotifText.text = "";
    }
}
