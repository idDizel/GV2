using GV2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GV2.Core.Implementation
{
    public class Player: IPlayer
    {
        public string Name { get; set; }
        public UnityEngine.Color Color { get; set; }
    }
}
