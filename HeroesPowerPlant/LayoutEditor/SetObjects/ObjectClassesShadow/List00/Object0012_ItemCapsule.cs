﻿namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0012_ItemCapsule : SetObjectManagerShadow
    {
        public ItemShadow Item
        {
            get => (ItemShadow)ReadInt(0);
            set => Write(0, (int)value);
        }
    }
}
