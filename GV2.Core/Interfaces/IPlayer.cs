using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        Color Color { get; set; }
    }
}
