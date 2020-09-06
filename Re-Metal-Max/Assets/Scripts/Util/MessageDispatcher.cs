using System;
using System.Reflection;
using System.Collections.Generic;

using ReMetalMax.Util.Attributes;

namespace ReMetalMax.Util
{
    public delegate void MessageCallBack(object msg);

    public class MessageDispatcher
    {
        public static readonly MessageDispatcher CoreInstance = new MessageDispatcher();
        public static readonly MessageDispatcher Instance = new MessageDispatcher();

        private Dictionary<object, MessageCallBack> m_msgDict = new Dictionary<object, MessageCallBack>();

        private Dictionary<Type, LinkedList<Tuple<object, MethodInfo>>> m_attributedMethodsCache = new Dictionary<Type, LinkedList<Tuple<object, MethodInfo>>>();

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

        private void _HandleMessageRegistrationAttribute(object obj, Action<object, MessageCallBack> action)
        {
            var type = obj.GetType();

            // cache
            if (m_attributedMethodsCache.ContainsKey(type))
            {
                var methodList = m_attributedMethodsCache[type];
                foreach (var methodTuple in methodList)
                {
                    (var key, var method) = methodTuple;
                    var deleg = Delegate.CreateDelegate(typeof(MessageCallBack), obj, method);
                    action(key, deleg as MessageCallBack);
                }
            }
            else
            {
                var methodsColl = new LinkedList<Tuple<object, MethodInfo>>();
                var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (var attribute in attributes)
                    {
                        if (attribute is MessageRegisterInfo)
                        {
                            var key = (attribute as MessageRegisterInfo).Key;
                            var deleg = Delegate.CreateDelegate(typeof(MessageCallBack), obj, method);
                            methodsColl.AddLast(new Tuple<object, MethodInfo>(key, method));

                            action(key, deleg as MessageCallBack);
                            break;
                        }
                    }
                }

                if (methodsColl.Count > 0)
                {
                    m_attributedMethodsCache[type] = methodsColl;
                }
            }

        }

        public void MessageRegistration(object obj) =>
            _HandleMessageRegistrationAttribute(obj, (key, deleg) =>
            {
                this.Register(key, deleg);
            });

        public void MessageUnregistration(object obj) =>
            _HandleMessageRegistrationAttribute(obj, (key, deleg) =>
            {
                this.Unregister(key, deleg);
            });

        public void Clear()
        {
            m_msgDict.Clear();
        }

        public void DispatchAsync()
        {
        }

        public void SendAsync()
        {

        }
    }
}
