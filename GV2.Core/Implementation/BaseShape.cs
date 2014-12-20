using GV2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Implementation
{
    public abstract class BaseShape: IShape
    {
        private GameObject shapeObject;

        public abstract float OffsetX { get; }
        public abstract float OffsetY { get; }

        protected GameObject ShapeObject
        {
            get
            {
                if (shapeObject == null)
                    throw new Exception("Node Object not instantiated");
                else
                    return shapeObject;
            }
            set
            {
                shapeObject = value;
            }
        }

        public BaseShape()
        {
            shapeObject = new GameObject();
        }

        public abstract void InitializeMesh();

        public GameObject GetInstance(Vector3 vector)
        {
            return (GameObject)GameObject.Instantiate(ShapeObject, vector, Quaternion.identity);
        }

        public void DestroyNode()
        {
            MonoBehaviour.Destroy(ShapeObject);
        }
    }
}
