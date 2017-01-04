using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

namespace TouchControl
{

    public class EventPositionTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler , IDragHandler, IMoveHandler
    {

        #region Head

        public delegate void OnPointerEventEventHandler(PointerEventData eventData);
        public event OnPointerEventEventHandler OnPointerDownPosition;
        public event OnPointerEventEventHandler OnPointerUpPosition;
        public event OnPointerEventEventHandler OnPointerDragPosition;

      

        #endregion

        #region public methods


        public void OnPointerDown(PointerEventData eventData)
        {
            if (OnPointerDownPosition != null)
                OnPointerDownPosition(eventData);

            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (OnPointerUpPosition != null)
                OnPointerUpPosition(eventData);

        }

        public void OnMove(AxisEventData eventData)
        {
            //Debug.Log("move");
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("drag");

            if (OnPointerDragPosition != null)
                OnPointerDragPosition(eventData);
        }

        #endregion
    }
}
