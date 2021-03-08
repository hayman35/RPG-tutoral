using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        MonoBehaviour currentAction;
        public void StartAction(MonoBehaviour action)
        {
            if(action == currentAction) return;
            if(currentAction != null)
            {
                print("Cancelling " + currentAction);
            }
            currentAction = action;
        }
    }

}

