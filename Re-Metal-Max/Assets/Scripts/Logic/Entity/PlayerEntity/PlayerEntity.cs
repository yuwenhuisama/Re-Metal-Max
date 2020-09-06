using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ReMetalMax.Core;

namespace ReMetalMax.Logic.PlayerEntity
{
    class PlayerEntity : MonoBehaviour, IEntity
    {
        private GameObject m_entityPrefab;
        private IController m_controller;
        private ISource m_entitySource;
        public GameObject EntityPrefab { get; set; }
        public ISource EntitySource { get; set; }
    }
}
