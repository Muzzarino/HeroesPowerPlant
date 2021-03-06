﻿namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0BBE_Chao : SetObjectManagerShadow
    {
        public Chao ChaoType
        {
            get => (Chao)ReadInt(0);
            set => Write(0, (int)value);
        }

        public float Unknown04
        {
            get => ReadFloat(4);
            set => Write(4, value);
        }

        public float Unknown08
        {
            get => ReadFloat(8);
            set => Write(8, value);
        }
    }

    public enum Chao
    {
        Normal = 0x00,
        Cheese = 0x01
    }
}
