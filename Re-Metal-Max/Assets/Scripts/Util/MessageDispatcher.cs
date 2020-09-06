using System;
using System.Collections.Generic;

namespace ReMetalMax.Util
{
    public delegate void MessageCallBack(object msg);

    public class MessageDispatcher
    {
        public static readonly MessageDispatcher CoreInstance = new MessageDispatcher();
        public static readonly MessageDispatcher Instance = new MessageDispatcher();

        private Dictionary<object, MessageCallBack> m_msgDict = new Dictionary<object, MessageCallBack>();

        public void Send(object token, object msg)
        {
            if (m_msgDict.ContainsKey(token))
            {
                m_msgDict[token].Invoke(msg);
            }
        }

        public void Register(object token, MessageCallBack msg)
        {
            if (m_msgDict.ContainsKey(msg))
            {
                m_msgDict[token] += msg;
            }
            else
            {
                m_msgDict[token] = msg;
            }
        }

        public void Unregister(object token, MessageCallBack msg)
        {
            if (m_msgDict.ContainsKey(token))
            {
                m_msgDict[token] -= msg;
                if (m_msgDict[token] == null)
                {
                    m_msgDict.Remove(token);
                }
            }
        }

        public void DispatchAsync()
        {
        }

        public void SendAsync()
        {

        }
    }
}
