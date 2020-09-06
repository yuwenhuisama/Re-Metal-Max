using UnityEngine;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class InstantiateSpriteEvent : BaseEvent
    {
        private GameObject m_spritePrefab;
        private Transform m_spriteParent = null;

        private string m_name;

        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public InstantiateSpriteEvent(GameObject prefab, string name, Transform parent = null)
        {
            m_spritePrefab = prefab;
            m_spriteParent = parent;
            m_name = name;
        }

        public override void Excute(EventContext context)
        {
            if (m_spritePrefab != null)
            {
                var obj = GameObject.Instantiate(m_spritePrefab, this.Position, this.Rotation, m_spriteParent);
                context[m_name] = obj;
            }
            this.IsDone = true;
        }
    }
}
