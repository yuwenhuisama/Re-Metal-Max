using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReMetalMax.Core
{
    public interface IController
    {
        void OnAttach();

        void OnDeattach();
    }
}
