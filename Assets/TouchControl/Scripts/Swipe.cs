using UnityEngine;
using System.Collections;

namespace TouchControl
{

    public class Swipe : MonoBehaviour
    {

        // Swipe
        public enum Gesture
        {
            Unkown,
            SwipeDown,
            SwipeUp,
            SwipeLeft,
            SwipeRight
        }

        public delegate void OnSwipeEventHandler(Gesture type);
        public event OnSwipeEventHandler OnSwipe;

        Vector2 firstPressPos;
        Vector2 secondPressPos;

        private float timePressed;


        // Update is called once per frame
        void Update()
        {
            ComputeSwipe();
        }



        public void ComputeSwipe()
        {
            if (OnSwipe != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //save began touch 2d point
                    firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    timePressed = Time.time;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    //save ended touch 2d point
                    secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);


                    if (Time.time - timePressed < 1.0f) // Ok, ich gehe davon aus, alles was länger als 1 Sekunde ist ist keinn swipe mehr.
                    {
                        Gesture type = Gesture.Unkown;
                        float xDelta = firstPressPos.x - secondPressPos.x;
                        float yDelta = firstPressPos.y - secondPressPos.y;

                        if (Mathf.Abs(xDelta) > Mathf.Abs(yDelta))
                        {
                            if (Mathf.Abs(xDelta) > Screen.width / 5) // Son fünftel sollte man schon durch wischen!
                            {

                                if (xDelta > 0.0f)
                                {
                                    type = Gesture.SwipeRight;
                                }
                                else
                                {
                                    type = Gesture.SwipeLeft;
                                }

                                OnSwipe(type);
                            }
                        }
                        else
                        {
                            if (Mathf.Abs(yDelta) > Screen.width / 5) // Son fünftel sollte man schon durch wischen!
                            {

                                if (yDelta > 0.0f)
                                {
                                    type = Gesture.SwipeUp;
                                }
                                else
                                {
                                    type = Gesture.SwipeDown;
                                }

                                OnSwipe(type);
                            }
                        }
                    }
                }

            }
        }

    }

}