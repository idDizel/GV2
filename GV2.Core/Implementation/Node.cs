using GV2.Core.Interfaces;
using GV2.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Implementation
{
    public class Node: INode
    {
        public GameObject NodeObject { get; set; }
        public Point Point { get; set; }
        public IPlayer Owner { get; set; }
    }
}
