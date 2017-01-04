using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace TouchControl
{

    public class MoveStick : MonoBehaviour {


        // Anzeige
        public Image StickImage;
        public EventPositionTrigger PositionTrigger;
        public bool XAxisEnable = true;
        public bool YAxisEnable = true;
        public bool crossMode;
        private Vector2 crossModeDelta;

        public float StickRange = 50.0f;

        // Status
        public Vector2 Axis;

        // Use this for initialization
        void Start () {
            PositionTrigger.OnPointerDragPosition += OnDrag;
        }
    
        // Update is called once per frame
        void Update () {
    
        }


        public void OnDrag(PointerEventData eventData)
        {
            var newPostion = StickImage.rectTransform.localPosition;


            if (crossMode)
            {
                crossModeDelta += eventData.delta;

                if (Mathf.Abs(crossModeDelta.x) > (StickRange / 2.0f) || Mathf.Abs(crossModeDelta.y) > (StickRange / 2.0f))
                {
                    // Horizontal
                    if (Mathf.Abs(crossModeDelta.x) > Mathf.Abs(crossModeDelta.y))
                    {
                        if (crossModeDelta.x > 1.0f) // left
                        {
                            newPostion.x = StickRange;
                            newPostion.y = 0.0f;
                        }
                        else if (crossModeDelta.x < -1.0f) // right
                        {
                            newPostion.x = StickRange * -1;
                            newPostion.y = 0.0f;
                        }
                        else // center
                        {
                            newPostion.x = 0.0f;
                            newPostion.y = 0.0f;
                        }

                    }
                    else // Vertical
                    {
                        if (crossModeDelta.y > 1.0f) // up
                        {
                            newPostion.y = StickRange;
                            newPostion.x = 0.0f;
                        }
                        else if (crossModeDelta.y < -1.0f) // down
                        {
                            newPostion.y = StickRange * -1;
                            newPostion.x = 0.0f;
                        }
                        else //center
                        {
                            newPostion.y = 0.0f;
                            newPostion.x = 0.0f;
                        }
                    }

                    crossModeDelta = Vector2.zero;
                }

            }
            else
            {

                if (XAxisEnable)
                {
                    newPostion.x += eventData.delta.x;

                    if (newPostion.x > StickRange)
                        newPostion.x = StickRange;

                    if (newPostion.x < (StickRange * -1))
                        newPostion.x = (StickRange * -1);
                }

                if (YAxisEnable)
                {
                    newPostion.y += eventData.delta.y;

                    if (newPostion.y > StickRange)
                        newPostion.y = StickRange;

                    if (newPostion.y < (StickRange * -1))
                        newPostion.y = (StickRange * -1);
                }
            }

            StickImage.rectTransform.localPosition = new Vector3(newPostion.x, newPostion.y);

            // Compute state
            Axis = newPostion / StickRange; // Auf 1.0f max normalisieren.

        }

        public void EndClick()
        {
            StickImage.rectTransform.localPosition = Vector3.zero;
            Axis = Vector2.zero; 
        }



    }
}