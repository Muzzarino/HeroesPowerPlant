﻿using SharpDX;

namespace HeroesPowerPlant.LayoutEditor
{
    public enum TriggerMusicShape
    {
        Sphere = 0,
        Cylinder = 1,
        Cube = 2
    }

    public class Object110C_TriggerMusic : SetObjectManagerHeroes
    {
        private BoundingSphere sphereBound;

        public override bool TriangleIntersection(Ray r, string[][] modelNames, int miscSettingByte, float initialDistance, out float distance)
        {
            switch (TriggerShape)
            {
                case TriggerMusicShape.Sphere:
                    return r.Intersects(ref sphereBound, out distance);
                case TriggerMusicShape.Cube:
                    return TriangleIntersection(r, Program.MainForm.renderer.cubeTriangles, Program.MainForm.renderer.cubeVertices, initialDistance, out distance, 0.25f);
                case TriggerMusicShape.Cylinder:
                    return TriangleIntersection(r, Program.MainForm.renderer.cylinderTriangles, Program.MainForm.renderer.cylinderVertices, initialDistance, out distance);
                default:
                    return base.TriangleIntersection(r, modelNames, miscSettingByte, initialDistance, out distance);
            }
        }

        public override BoundingBox CreateBoundingBox(string[][] modelNames, int miscSettingByte)
        {
            return new BoundingBox(-Vector3.One / 2, Vector3.One / 2);
        }

        public override void CreateTransformMatrix(Vector3 Position, Vector3 Rotation)
        {
            this.Position = Position;
            this.Rotation = Rotation;

            switch (TriggerShape)
            {
                case TriggerMusicShape.Sphere:
                    sphereBound = new BoundingSphere(Position, Radius_ScaleX);
                    transformMatrix = Matrix.Scaling(Radius_ScaleX * 2);
                    break;
                case TriggerMusicShape.Cube:
                    transformMatrix = Matrix.Scaling(Radius_ScaleX * 2, Height_ScaleY * 2, ScaleZ * 2);
                    break;
                case TriggerMusicShape.Cylinder:
                    transformMatrix = Matrix.Scaling(Radius_ScaleX * 2, Height_ScaleY * 2, Radius_ScaleX * 2);
                    break;
            }

            transformMatrix = transformMatrix
                * Matrix.RotationY(ReadWriteCommon.BAMStoRadians(Rotation.Y))
                * Matrix.RotationX(ReadWriteCommon.BAMStoRadians(Rotation.X))
                * Matrix.RotationZ(ReadWriteCommon.BAMStoRadians(Rotation.Z))
                * Matrix.Translation(Position);
        }

        public override void Draw(SharpRenderer renderer, string[][] modelNames, int miscSettingByte, bool isSelected)
        {
            switch (TriggerShape)
            {
                case TriggerMusicShape.Sphere:
                    renderer.DrawSphereTrigger(transformMatrix, isSelected);
                    break;
                case TriggerMusicShape.Cube:
                    renderer.DrawCubeTrigger(transformMatrix, isSelected);
                    break;
                case TriggerMusicShape.Cylinder:
                    renderer.DrawCylinderTrigger(transformMatrix, isSelected);
                    break;
                default:
                    DrawCube(renderer, isSelected);
                    break;
            }
        }

        public short MusicNumber
        {
            get => ReadShort(4);
            set => Write(4, value);
        }

        public TriggerMusicShape TriggerShape
        {
            get => (TriggerMusicShape)ReadInt(8);
            set { Write(8, (int)value); CreateTransformMatrix(Position, Rotation); }
        }

        public float Radius_ScaleX
        {
            get => ReadFloat(12);
            set { Write(12, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float Height_ScaleY
        {
            get => ReadFloat(16);
            set { Write(16, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float ScaleZ
        {
            get => ReadFloat(20);
            set { Write(20, value); CreateTransformMatrix(Position, Rotation); }
        }
    }
}