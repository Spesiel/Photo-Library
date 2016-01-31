using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public class LibraryObjects : Cache<CacheObject>
    {
        public LibraryObjects() : base(Constants.CacheFullPath)
        {
        }

        #region Tags: GetAll/FindBy

        public IEnumerable<string> AllTags
        {
            get
            {
                List<string> ans = new List<string>();
                Parallel.ForEach(_Library.Values.ToList(), Constants.ParallelOptions,
                    current =>
                    {
                        ans.AddRange(current.Properties.Tags);
                    });

                return ans.Distinct();
            }
        }

        public IEnumerable<CacheObject> FindByTag(string tag)
        {
            return _Library.Values.Where(v => v.Properties.Tags.Contains(tag));
        }

        public IEnumerable<CacheObject> FindByTags(IList<string> tags)
        {
            return _Library.Values.Where(v => v.Properties.Tags.Any(t => tags.Contains(t)));
        }

        #endregion Tags: GetAll/FindBy
    }
}