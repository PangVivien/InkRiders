using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class FreeLookCam : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Image controlArea;
    [SerializeField] CinemachineFreeLook freeLook;
    string strMouseX = "Mouse X", strMouseY = "Mouse Y";

    // Start is called before the first frame update
    void Start()
    {
        controlArea = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(controlArea.rectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out Vector2 posOut))
        {
            //Debug.Log(posOut);
            freeLook.m_XAxis.m_InputAxisName = strMouseX;
            freeLook.m_XAxis.m_InputAxisName = strMouseY;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        freeLook.m_XAxis.m_InputAxisName = null;
        freeLook.m_YAxis.m_InputAxisName = null;
        freeLook.m_XAxis.m_InputAxisValue = 0;
        freeLook.m_YAxis.m_InputAxisValue = 0;
    }

}
