﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GV2.Core;
//using GV2.Core.Implementation;

public class Generator : MonoBehaviour {

	void Start()
	{
        MapFacade mapFacade = new MapFacade();
        mapFacade.GenetrateGrid(5, 5);
	}
}
