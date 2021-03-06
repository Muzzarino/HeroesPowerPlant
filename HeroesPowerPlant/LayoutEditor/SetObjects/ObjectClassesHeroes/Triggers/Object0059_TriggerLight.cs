﻿using SharpDX;

namespace HeroesPowerPlant.LayoutEditor
{
    public enum TriggerLightNumber
    {
        Player0 = 0,
        Player1 = 1,
        Player2 = 2,
        Player3 = 3,
        Object0 = 4,
        Object1 = 5,
        Object2 = 6,
        Object3 = 7,
        Enemy0 = 8,
        Enemy1 = 9,
        Enemy2 = 10,
        Enemy3 = 11,
        NotInUnse = 12,
        Other0 = 13,
        Other1 = 14,
        Other2 = 15,
        Ignore = 16
    }

    public enum TriggerLightType
    {
        Area = 0,
        Switch = 1,
        AreaDef = 2,
        SwitchOff = 3
    }

    public enum TriggerLightShape
    {
        Cube = 0,
        Sphere = 1,
        Cylinder = 2,
        NotInUse = 3
    }

    public class Object0059_TriggerLight : SetObjectManagerHeroes
    {
        private BoundingSphere sphereBound;

        public override bool TriangleIntersection(Ray r, string[][] modelNames, int miscSettingByte, float initialDistance, out float distance)
        {
            switch (TriggerShape)
            {
                case TriggerLightShape.Sphere:
                    return r.Intersects(ref sphereBound, out distance);
                case TriggerLightShape.Cube:
                    return TriangleIntersection(r, Program.MainForm.renderer.cubeTriangles, Program.MainForm.renderer.cubeVertices, initialDistance, out distance, 0.25f);
                case TriggerLightShape.Cylinder:
                    return TriangleIntersection(r, Program.MainForm.renderer.cylinderTriangles, Program.MainForm.renderer.cylinderVertices, initialDistance, out distance);
                default:
                    return base.TriangleIntersection(r, modelNames, miscSettingByte, initialDistance, out distance);
            }
        }

        public override BoundingBox CreateBoundingBox(string[][] modelNames, int miscSettingByte)
        {
            if (TriggerShape == TriggerLightShape.NotInUse)
                return base.CreateBoundingBox(modelNames, miscSettingByte);
            else
                return new BoundingBox(-Vector3.One / 2, Vector3.One / 2);
        }

        public override void CreateTransformMatrix(Vector3 Position, Vector3 Rotation)
        {
            this.Position = Position;
            this.Rotation = Rotation;
            
            switch (TriggerShape)
            {
                case TriggerLightShape.Sphere:
                    sphereBound = new BoundingSphere(Position, Radius);
                    transformMatrix = Matrix.Scaling(Radius * 2);
                    break;
                case TriggerLightShape.Cube:
                    transformMatrix = Matrix.Scaling(ScaleX * 2, ScaleY * 2, ScaleZ * 2);
                    break;
                case TriggerLightShape.Cylinder:
                    transformMatrix = Matrix.Scaling(Radius * 2, Height * 2, Radius * 2);
                    break;
                case TriggerLightShape.NotInUse:
                    base.CreateTransformMatrix(Position, Rotation);
                    return;
            }

            transformMatrix = transformMatrix
                * Matrix.RotationZ(ReadWriteCommon.BAMStoRadians(Rotation.Z))
                * Matrix.RotationY(ReadWriteCommon.BAMStoRadians(Rotation.Y))
                * Matrix.RotationX(ReadWriteCommon.BAMStoRadians(Rotation.X))
                * Matrix.Translation(Position);
        }

        public override void Draw(SharpRenderer renderer, string[][] modelNames, int miscSettingByte, bool isSelected)
        {
            if (TriggerShape == TriggerLightShape.Cube)
                renderer.DrawCubeTrigger(transformMatrix, isSelected);
            
            else if (TriggerShape == TriggerLightShape.Sphere)
                renderer.DrawSphereTrigger(transformMatrix, isSelected);
            
            else if (TriggerShape == TriggerLightShape.Cylinder)
                renderer.DrawCylinderTrigger(transformMatrix, isSelected);
            
            else if (TriggerShape ==  TriggerLightShape.NotInUse)
                DrawCube(renderer, isSelected);
        }

        public TriggerLightNumber Number
        {
            get => (TriggerLightNumber)ReadByte(4);
            set => Write(4, (byte)value);
        }

        public TriggerLightType Type
        {
            get => (TriggerLightType)ReadByte(5);
            set => Write(5, (byte)value);
        }

        public TriggerLightShape TriggerShape
        {
            get => (TriggerLightShape)ReadByte(6);
            set { Write(6, (byte)value); CreateTransformMatrix(Position, Rotation); }
        }

        public float Radius
        {
            get => ReadFloat(8);
            set { Write(8, value); CreateTransformMatrix(Position, Rotation); }
        }

        public float Height
        {
            get => ReadFloat(12);
            set { Write(12, value); CreateTransformMatrix(Position, Rotation); }
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