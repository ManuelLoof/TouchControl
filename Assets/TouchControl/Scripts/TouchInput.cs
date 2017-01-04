using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace TouchControl
{
    public static class TouchInput
    {
        public static TouchInputControls Controls;
        public static Canvas ControlCanvas;

        private static Dictionary<string, MoveStick> _sticks = new Dictionary<string, MoveStick>();
        private static Dictionary<string, AnimateButton> _buttons = new Dictionary<string, AnimateButton>();


        public static void SetVisible()
        {
            if (ControlCanvas != null)
            {
                ControlCanvas.gameObject.SetActive(true);
            }
        }
        public static void SetInvisible()
        {
            if (ControlCanvas != null)
            {
                ControlCanvas.gameObject.SetActive(false);
            }
        }

        public static Vector2 JoystickValue(string deviceName)
        {
            if (Controls != null)
            {
                var stick = GetStickControl(deviceName);

                if (stick != null)
                    return stick.Axis;
            }

            return Vector2.zero;
        }


        public static bool GetButtonUp(string deviceName)
        {
            if (Controls != null)
            {
                var button = GetButtonControl(deviceName);

                if (button != null)
                    return button.GetButtonUp();
            }

            return false;
        }
        public static bool GetButton(string deviceName)
        {
            if (Controls != null)
            {
                var button = GetButtonControl(deviceName);

                if (button != null)
                    return button.GetButton();
            }

            return false;
        }
        public static bool GetButtonDown(string deviceName)
        {
            if (Controls != null)
            {
                var button = GetButtonControl(deviceName);

                if (button != null)
                    return button.GetButtonDown();
            }

            return false;
        }


        #region private methods

        /// <summary>
        /// Liefert den gewünschten Stick und Cached in ein.
        /// </summary>
        /// <param name="name">Der Name des Joysticks.</param>
        /// <returns>Null, falls nicht vorhanden.</returns>
        private static MoveStick GetStickControl(string name)
        {

            MoveStick stick = null;

            if (_sticks.ContainsKey(name))
            {
                stick = _sticks[name];

                if (stick != null)
                    return stick;
            }

            if (Controls != null)
            {
                stick = Controls.GetStick(name);

                if (stick != null)
                {
                    // Es kommt vor wenn er z.B. eine neue Scene läd, das er die Referenz auf das Objekt verliehrt, aber den Key noch im Diconary hat.
                    // dann einfach ein Eintrag updaten statt einen neuen hinzufügen.
                    if (_sticks.ContainsKey(name))
                    {
                        _sticks[name] = stick;
                    }
                    else
                    {
                        _sticks.Add(name, stick);
                    }
                    return stick;
                }

            }


            return null;
        }


        /// <summary>
        /// Liefert den gewünschten Stick und Cached in ein.
        /// </summary>
        /// <param name="name">Der Name des Buttons.</param>
        /// <returns>Null, falls nicht vorhanden.</returns>
        private static AnimateButton GetButtonControl(string name)
        {
            AnimateButton button = null;

            if (_buttons.ContainsKey(name))
            {
                button = _buttons[name];

                if (button != null)
                    return button;
            }

            if (Controls != null)
            {
                button = Controls.GetButton(name);

                if (button != null)
                {
                    // Es kommt vor wenn er z.B. eine neue Scene läd, das er die Referenz auf das Objekt verliehrt, aber den Key noch im Diconary hat.
                    // dann einfach ein Eintrag updaten statt einen neuen hinzufügen.
                    if (_buttons.ContainsKey(name))
                    {
                        _buttons[name] = button;
                    }
                    else
                    {
                        _buttons.Add(name, button);
                    }
                    return button;
                }

            }


            return null;
        }



        #endregion

    }
}