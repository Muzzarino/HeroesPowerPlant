﻿using SharpDX;

namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0182_Whale : SetObjectManagerHeroes
    {
        private Matrix triggerMatrix;

        public override void CreateTransformMatrix(Vector3 Position, Vector3 Rotation)
        {
            base.CreateTransformMatrix(Position, Rotation);

            triggerMatrix = Matrix.Scaling(TriggerSize) * Matrix.Translation(TriggerX, TriggerY, TriggerZ);
        }

        public override void Draw(SharpRenderer renderer, string[][] modelNames, int miscSettingByte, bool isSelected)
        {
            base.Draw(renderer, modelNames, miscSettingByte, isSelected);

            if (isSelected)
                renderer.DrawSphereTrigger(triggerMatrix, true);
        }

        public byte WhaleType
        {
            get => ReadByte(4);
            set => Write(4, value);
        }

        public short TriggerSize
        {
            get => ReadShort(6);
            set { Write(6, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float WhaleScale
        {
            get => ReadFloat(8);
            set => Write(8, value);
        }

        public float ArchRadius
        {
            get => ReadFloat(12);
            set => Write(12, value);
        }

        public float TriggerX
        {
            get => ReadFloat(16);
            set { Write(16, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float TriggerY
        {
            get => ReadFloat(20);
            set { Write(20, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float TriggerZ
        {
            get => ReadFloat(24);
            set { Write(24, value); CreateTransformMatrix(Position, Rotation); }
        }
    }
}
