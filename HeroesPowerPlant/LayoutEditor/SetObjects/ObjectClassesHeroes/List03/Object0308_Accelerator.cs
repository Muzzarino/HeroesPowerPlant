﻿using SharpDX;

namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0308_Accelerator : SetObjectManagerHeroes
    {
        public override BoundingBox CreateBoundingBox(string[][] modelNames, int miscSettingByte)
        {
            return new BoundingBox(-Vector3.One / 2, Vector3.One / 2);
        }

        public override void CreateTransformMatrix(Vector3 Position, Vector3 Rotation)
        {
            base.CreateTransformMatrix(Position, Rotation);

            transformMatrix = Matrix.Scaling(ScaleX, ScaleY, ScaleZ) * transformMatrix;
        }

        public override void Draw(SharpRenderer renderer, string[][] modelNames, int miscSettingByte, bool isSelected)
        {
            renderer.DrawCubeTrigger(transformMatrix, isSelected);
        }

        public float Speed
        {
            get => ReadFloat(4);
            set => Write(4, value);
        }

        public float ScaleX
        {
            get => ReadFloat(8);
            set { Write(8, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float ScaleY
        {
            get => ReadFloat(12);
            set { Write(12, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float ScaleZ
        {
            get => ReadFloat(16);
            set { Write(16, value); CreateTransformMatrix(Position, Rotation); }
        }
    }
}