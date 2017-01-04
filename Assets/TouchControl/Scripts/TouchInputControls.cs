using UnityEngine;
using System.Collections;
using System.Linq;

namespace TouchControl
{

    public class TouchInputControls : MonoBehaviour {

        public MoveStick[] JoySticks;
        public AnimateButton[] Buttons;

        public MoveStick GetStick(string name)
        {
            return JoySticks.ToList().Where(s => s.gameObject.transform.parent.name == name).FirstOrDefault(); 
        }

        public AnimateButton GetButton(string name)
        {
            return Buttons.ToList().Where(b => b.gameObject.transform.parent.name == name).FirstOrDefault();
        }
    }
}