﻿using GV2.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Interfaces
{
    public interface IMap<T> where T: IShape
    {
        Dictionary<Point, GameObject> Generate(int width, int height, T shape);
        IEnumerable<Point> GetNeighbors(Point point);
    }
}