using System.Collections.Generic;
using UnityEngine;

namespace ReMetalMax.Core.Event
{
    public class EventContext
    {
        LinkedList<IEvent> m_eventQueue = new LinkedList<IEvent>();
        Dictionary<string, GameObject> m_contextDict = new Dictionary<string, GameObject>();
        
        public long FrameCount { get; private set; } = 0;

        public IEvent FrontEvent => m_eventQueue.Count == 0 ? null : m_eventQueue.First.Value;

        public int EventCount => m_eventQueue.Count;

        public void Push(IEvent newEvent)
        {
            newEvent.Frame = this.FrameCount;
            m_eventQueue.AddLast(newEvent);
        }

        public void PushToNextFrame(IEvent newEvent)
        {
            newEvent.Frame = this.FrameCount + 1;
            m_eventQueue.AddLast(newEvent);
        }

        public IEvent Pop() 
        {
            if (m_eventQueue.Count == 0) {
                return null;
            }
            var first = m_eventQueue.First;
            m_eventQueue.RemoveFirst();
            return first.Value;
        }

        public GameObject this[string name]
        {
            get => m_contextDict.ContainsKey(name) ? m_contextDict[name] : null;
            set => m_contextDict[name] = value;
        }

        public void RemoveFromDict(string name)
        {
            if (this.m_contextDict.ContainsKey(name))
            {
                this.m_contextDict.Remove(name);
            }
        }

        public void UpdateFrame()
        {
            ++this.FrameCount;
        }
    }
}