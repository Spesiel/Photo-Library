using PhotoLibrary.Cache.Objects;
using PhotoLibrary.Reference;

namespace PhotoLibrary.Cache
{
    public class Persons : Cache<Person>
    {
        //FIXME Change the path
        public Persons() : base(Constants.CacheFullPath + "Persons")
        {
        }
    }
}