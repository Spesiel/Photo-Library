using PhotoLibrary.Reference;

namespace PhotoLibrary.Cache
{
    public class Tags : CacheList<string>
    {
        //FIXME Change the path
        public Tags() : base(Constants.CacheFullPath + "Tags")
        {
        }
    }
}