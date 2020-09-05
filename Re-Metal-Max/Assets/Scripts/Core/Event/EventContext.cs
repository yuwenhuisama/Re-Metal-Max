using System.Collections.Generic;
using UnityEngine;

namespace ReMetalMax.Core.Event
{
    public class EventContext
    {
        Queue<IEvent> m_eventQueue = new Queue<IEvent>();
        Dictionary<string, GameObject> m_contextDict = new Dictionary<string, GameObject>();
        
        public void Push(IEvent newEvent)
        {
            m_eventQueue.Enqueue(newEvent);
        }

        public IEvent Pop() 
        {
            if (m_eventQueue.Count == 0) {
                return null;
            }
            return m_eventQueue.Dequeue();
        }

        public GameObject GetGameObject(string name) {
            if (m_contextDict.ContainsKey(name)) {
                return m_contextDict[name];
            }

            return null;
        }
    }
}