﻿using PhotoLibrary.Cache.Objects;
using PhotoLibrary.Reference;

namespace PhotoLibrary.Cache
{
    public class Items : CacheSingleton<Item>
    {
        //FIXME Change the path
        public Items() : base(Constants.CacheFullPath)
        {
        }
    }
}