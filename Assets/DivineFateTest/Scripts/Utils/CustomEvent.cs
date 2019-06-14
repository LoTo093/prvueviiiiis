using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Tuple;

namespace CustomEvents
{

    public class CustomEvent
    {

        UnityEvent call; //should not be inherited for obvious reasons

        public virtual void Invoke()
        { //should be always overriden
            call.Invoke();
        }

        public static void InvokeAll(List<CustomEvent> allEvents)
        {
            for (int i = 0; i < allEvents.Count; i++)
            {
                allEvents[i].Invoke();
            }
        }

        public void Initialize(UnityEvent c)
        {
            call = c;
        }

    }

    //Define the Class
    public sealed class CustomEvent<T> : CustomEvent
    {

        Tuple<T> parameters;
        UnityEvent<T> call;

        public override void Invoke()
        {
            T first = parameters.Item1; //cosas de como van los eventos, es para scopear una copia local
            call.Invoke(first);
        }

        public void Initialize(UnityEvent<T> c, Tuple<T> p)
        {
            call = c;
            parameters = p;
        }
    }

}
