using UnityEngine;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class InstantiateUISpriteEvent : BaseEvent
    {
        private GameObject m_spritePrefab;
        private Transform m_spriteParent = null;

        private string m_name;

        public Vector3 Position { get; set; } = Vector3.zero;
        public Quaternion Rotation { get; set; } = Quaternion.identity;

        public InstantiateUISpriteEvent(GameObject prefab, string name, Transform parent = null)
        {
            m_spritePrefab = prefab;
            m_spriteParent = parent;
            m_name = name;
        }

        public override void Excute(EventContext context)
        {
            if (m_spritePrefab != null)
            {
                // var parent = GameObject.Find("UI").transform;
                var obj = GameObject.Instantiate(m_spritePrefab, m_spritePrefab.transform.position, m_spritePrefab.transform.rotation, GameObject.Find("UI").transform);
                obj.GetComponent<RectTransform>().anchoredPosition = m_spritePrefab.GetComponent<RectTransform>().anchoredPosition;
                context[m_name] = obj;
            }
            this.IsDone = true;
        }
    }
}
