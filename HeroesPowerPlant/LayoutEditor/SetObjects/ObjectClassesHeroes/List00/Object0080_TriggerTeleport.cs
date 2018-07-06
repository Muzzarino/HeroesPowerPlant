﻿using SharpDX;
using System;
using static HeroesPowerPlant.SharpRenderer;

namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0080_TriggerTeleport : SetObjectManagerHeroes
    {
        private Matrix triggerMatrix;
        private Matrix destinationMatrix;

        public override void CreateTransformMatrix(Vector3 Position, int XRot, int YRot, int ZRot)
        {
            destinationMatrix = Matrix.Translation(XDestination, YDestination, ZDestination);

            triggerMatrix = Matrix.Scaling(Radius)
                * Matrix.RotationY((float)(YRot * (Math.PI / 32768f)))
                * Matrix.RotationX((float)(XRot * (Math.PI / 32768f)))
                * Matrix.RotationZ((float)(ZRot * (Math.PI / 32768f)))
                * Matrix.Translation(Position);
        }

        public override void Draw(string[] modelNames, bool isSelected)
        {
            DrawCube(destinationMatrix, isSelected);
            DrawSphere(triggerMatrix, isSelected);
        }

        public float Radius
        {
            get { return ReadWriteSingle(4); }
            set { ReadWriteSingle(4, value); }
        }

        public float XDestination
        {
            get { return ReadWriteSingle(8); }
            set { ReadWriteSingle(8, value); }
        }

        public float YDestination
        {
            get { return ReadWriteSingle(12); }
            set { ReadWriteSingle(12, value); }
        }

        public float ZDestination
        {
            get { return ReadWriteSingle(16); }
            set { ReadWriteSingle(16, value); }
        }
    }
}