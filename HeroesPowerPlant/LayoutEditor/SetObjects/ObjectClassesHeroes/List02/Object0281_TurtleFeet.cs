﻿namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0281_TurtleFeet : SetObjectManagerHeroes
    {
        public float Scale
        {
            get => ReadFloat(4);
            set => Write(4, value);
        }

        public float Speed
        {
            get => ReadFloat(8);
            set => Write(8, value);
        }
    }
}
