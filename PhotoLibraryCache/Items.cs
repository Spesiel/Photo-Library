using PhotoLibrary.Cache.Objects;
using PhotoLibrary.Reference;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public class Items : CacheSingleton<Item>
    {
        //FIXME Change the path
        public Items() : base(Constants.CacheFullPath)
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

        public IEnumerable<Item> FindByTag(string tag)
        {
            return _Library.Values.Where(v => v.Properties.Tags.Contains(tag));
        }

        public IEnumerable<Item> FindByTags(IList<string> tags)
        {
            return _Library.Values.Where(v => v.Properties.Tags.Any(t => tags.Contains(t)));
        }

        #endregion Tags: GetAll/FindBy
    }
}