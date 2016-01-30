using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace PhotoLibrary.Cache
{
    [Serializable]
    public struct CacheObject
    {
        private string _thumbnail { get; set; }

        private string _tags { get; set; }

        private string _exif { get; set; }

        public int PeopleCount { get; set; }

        [IgnoreDataMember]
        public Image Thumbnail
        {
            get
            {
                if (!string.IsNullOrEmpty(_thumbnail))
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(_thumbnail)))
                    {
                        return Image.FromStream(ms);
                    }
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        value.Save(ms, ImageFormat.Jpeg);
                        _thumbnail = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        [IgnoreDataMember]
        public IList<string> Tags
        {
            get
            {
                if (_tags == null)
                {
                    return new List<string>();
                }
                return _tags.Split('|');
            }
        }

        [IgnoreDataMember]
        public CacheExif Exif
        {
            get
            {
                if (_exif != null)
                {
                    return CacheExif.FromXml(_exif);
                }
                return new CacheExif();
            }
            set
            {
                _exif = CacheExif.ToXml(value);
            }
        }

        #region Tags: Add/Remove

        public void AddTag(string tag)
        {
            List<string> tags = Tags as List<string>;

            tags.Add(tag);

            SaveTags(tags);
        }

        public void AddTags(IList<string> tagsToAdd)
        {
            List<string> tags = Tags as List<string>;

            tags.AddRange(tagsToAdd);

            SaveTags(tags);
        }

        public bool RemoveTag(string tag)
        {
            List<string> tags = Tags as List<string>;

            bool ans = tags.Remove(tag);
            SaveTags(tags);
            return ans;
        }

        private void SaveTags(List<string> tags)
        {
            _tags = string.Join("|", tags.Distinct().OrderBy(t => t));
        }

        #endregion Tags: Add/Remove
    }
}