using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Interfaces
{
    public interface IShape
    {
        float OffsetX { get; }
        float OffsetY { get; }
        void InitializeMesh();
        GameObject GetInstance(Vector3 vector);
        void DestroyNode();
    }
}
