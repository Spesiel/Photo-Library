using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public class LibraryCache : Cache<CacheObject>
    {
        private static PersistentDictionary<string, CacheObject> _LibraryCache = new PersistentDictionary<string, CacheObject>(Constants.CacheFullPath);

        #region Tags: GetAll/FindBy

        public IEnumerable<string> AllTags
        {
            get
            {
                List<string> ans = new List<string>();
                Parallel.ForEach(_LibraryCache.Values.ToList(), Constants.ParallelOptions,
                    current =>
                    {
                        ans.AddRange(current.Tags);
                    });

                return ans.Distinct();
            }
        }

        public IEnumerable<CacheObject> FindByTag(string tag)
        {
            return _LibraryCache.Values.Where(v => v.Tags.Contains(tag));
        }

        public IEnumerable<CacheObject> FindByTags(IList<string> tags)
        {
            return _LibraryCache.Values.Where(v => v.Tags.Any(t => tags.Contains(t)));
        }

        #endregion Tags: GetAll/FindBy
    }
}