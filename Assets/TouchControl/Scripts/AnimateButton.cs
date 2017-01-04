using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace TouchControl
{

    public class AnimateButton : MonoBehaviour
    {

        public AnimationCurve ResizeAnimtaion = new AnimationCurve();
        public float EndScale = 0.8f;

        private float _animationStart;
        private bool _pressed;
        private bool _down;
        private bool _up;
        private bool _downUpdate;
        private bool _upUpdate;
        private float _scaleDiff;

        /// <summary>
        /// Color transformation
        /// </summary>
        public Image[] ImagesColorTransform;
        public Color StartColor = new Color(1f, 1f, 1f, 0.4f);
        public Color EndColor = new Color(1f, 0f, 0f, 0.4f);

        /// <summary>
        /// Position
        /// </summary>
        private Vector3 _startPosition;
        public bool MoveButton = true;
        public EventPositionTrigger _pointerDownPosition;


        // Use this for initialization
        void Start()
        {
            _scaleDiff = 1.0f - EndScale;
            _startPosition = this.transform.position;
            if (_pointerDownPosition != null)
                _pointerDownPosition.OnPointerDownPosition += StartClick;
        }

        // Update is called once per frame
        void Update()
        {
            AnimateAndScale();

            // Damit das Up Event nur einen frame call überlebt.
            if (_upUpdate && _upUpdate != _up)
            {
                _up = true;
                _upUpdate = false;
            }
            else if (_upUpdate != _up)
            {
                _up = false;
            }

            // Damit das Down Event nur einen frame call überlebt.
            if (_downUpdate && _downUpdate != _down)
            {
                _down = true;
                _downUpdate = false; 
            }
            else if (_downUpdate != _down)
            {
                _down = false;
            }

        }


        public void StartClick(PointerEventData eventData)
        {
            _pressed = true;
            _downUpdate = true;
            _up = false;
            _animationStart = Time.time;

            if(MoveButton)
                transform.position = eventData.position;


        }


        public void EndClick()
        {
            _pressed = false;
            _upUpdate = true;
            _down = false; 
            _animationStart = Time.time;
            if (MoveButton)
                transform.position = _startPosition;
        }


        public bool GetButtonUp()
        {
            return _up;
        }
        public bool GetButton()
        {
            return _pressed;
        }
        public bool GetButtonDown()
        {
            return _down;
        }


        private void AnimateAndScale()
        {
            float timeDiff = Time.time - _animationStart;

            if (timeDiff <= ResizeAnimtaion.keys[ResizeAnimtaion.length - 1].time)
            {
                float relativeTimeSpan = ResizeAnimtaion.Evaluate(timeDiff);

                if (_pressed)
                {
                    float actScaleSize = 1.0f - relativeTimeSpan * _scaleDiff;
                    transform.localScale = new Vector3(actScaleSize, actScaleSize);

                    for (int i = 0; i < ImagesColorTransform.Length; i++)
                    {
                        ImagesColorTransform[i].color = Color.Lerp(StartColor, EndColor, actScaleSize);
                    }

                }
                else
                {
                    float actScaleSize = EndScale + relativeTimeSpan * _scaleDiff;
                    transform.localScale = new Vector3(actScaleSize, actScaleSize);
                    for (int i = 0; i < ImagesColorTransform.Length; i++)
                    {
                        ImagesColorTransform[i].color = Color.Lerp(EndColor, StartColor, actScaleSize);
                    }
                }
            }
        }

    }
}