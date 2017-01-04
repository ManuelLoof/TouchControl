using UnityEngine;
using System.Collections;

namespace TouchControl
{

    public class TouchInputTest : MonoBehaviour
    {

        public TouchInputControls Controls;
        public Canvas ControlCanvas;

        // Use this for initialization
        void Start()
        {
            TouchInput.Controls = Controls;
            TouchInput.ControlCanvas = ControlCanvas;
        }

        // Update is called once per frame
        void Update()
        {
            string stickName = "Stick";
             string buttonRightName = "ButtonRight";
             string buttonLeftName = "ButtonLeft";

            if (TouchInput.JoystickValue(stickName) != Vector2.zero)
                Debug.Log(string.Format("{0}: {1}",stickName,TouchInput.JoystickValue(stickName)));



            if (TouchInput.GetButton(buttonRightName))
                Debug.Log(string.Format("{0} ({1}): {2}", buttonRightName, "GetButton", TouchInput.GetButton(buttonRightName)));

            if (TouchInput.GetButtonUp(buttonRightName))
                Debug.Log(string.Format("{0} ({1}): {2}", buttonRightName, "GetButtonUp", TouchInput.GetButtonUp(buttonRightName)));

            if (TouchInput.GetButtonDown(buttonRightName))
                Debug.Log(string.Format("{0} ({1}): {2}", buttonRightName, "GetButtonDown", TouchInput.GetButtonDown(buttonRightName)));



            if (TouchInput.GetButton(buttonLeftName))
                Debug.Log(string.Format("{0} ({1}): {2}", buttonLeftName, "GetButton", TouchInput.GetButton(buttonLeftName)));

            if(TouchInput.GetButtonUp(buttonLeftName))
                Debug.Log(string.Format("{0} ({1}): {2}", buttonLeftName, "GetButtonUp", TouchInput.GetButtonUp(buttonLeftName)));

            if(TouchInput.GetButtonDown(buttonLeftName))
                Debug.Log(string.Format("{0} ({1}): {2}", buttonLeftName, "GetButtonDown", TouchInput.GetButtonDown(buttonLeftName)));

        }
    }
}
