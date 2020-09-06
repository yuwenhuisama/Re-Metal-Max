using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReMetalMax.Core
{
    public interface IEntity
    {
        GameObject EntityPrefab { get; set; }
        ISource EntitySource { get; set; }
    }
}
