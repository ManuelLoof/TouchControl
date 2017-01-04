using UnityEngine;
using System.Collections;

namespace TouchControl
{

    public class SwipeTest : MonoBehaviour
    {

        public Swipe trigger;

        // Use this for initialization
        void Start()
        {
            trigger.OnSwipe += trigger_OnSwipe;
        }

        void trigger_OnSwipe(Swipe.Gesture type)
        {
            Debug.Log("Swipe");
            Debug.Log(type);
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}