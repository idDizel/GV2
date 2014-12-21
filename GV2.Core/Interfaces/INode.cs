using GV2.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Interfaces
{
    public interface INode
    {
        GameObject NodeObject { get; set; }
        IPlayer Owner { get; set; }
    }
}
