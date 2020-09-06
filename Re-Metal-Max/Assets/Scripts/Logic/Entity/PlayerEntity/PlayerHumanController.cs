using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ReMetalMax.Core;
using ReMetalMax.Core.Event;

namespace ReMetalMax.Logic.PlayerEntity
{
    class PlayerHumanController : IController
    {
        private EventContext m_context;
        private IEntity m_currentEntity;

        public void Attach(EventContext context, IEntity entity, ISource source = null) {
            OnAttach();
            m_context = context;
            m_currentEntity = entity;
            if (source != null) {
                m_currentEntity.EntitySource = source;
            }
        }
        public void OnAttach() { 
        
        }

        public void OnDeattach() { 
        
        }
    }
}
