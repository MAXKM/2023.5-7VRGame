using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickTest : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private NormalMonitorManager normalMonitorManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        normalMonitorManager.ReturnObjectToPool(this.gameObject);
    }
}
