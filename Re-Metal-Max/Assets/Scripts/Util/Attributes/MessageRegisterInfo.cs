using System;

namespace ReMetalMax.Util.Attributes
{
    public class MessageRegisterInfo : Attribute
    {
        private object m_key;
        public object Key
        {
            get => m_key;
            set
            {
                if (value == null)
                {
                    throw new Exception("Register Key Cannot be Null");
                }
                m_key = value;
            }
        }
    }
}
