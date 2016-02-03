using PhotoLibrary.Reference;

namespace PhotoLibrary.Cache
{
    public class Tags : Cache<string>
    {
        //FIXME Change the path
        public Tags() : base(Constants.CacheFullPath + "Tags")
        {
        }
    }
}