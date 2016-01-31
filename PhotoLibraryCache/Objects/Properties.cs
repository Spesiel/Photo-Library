using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Properties
    {
        private string _Thumbnail { get; set; }

        private string _Tags { get; set; }

        [IgnoreDataMember]
        public Image Thumbnail
        {
            get
            {
                if (!string.IsNullOrEmpty(_Thumbnail))
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(_Thumbnail)))
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
                        _Thumbnail = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        [IgnoreDataMember]
        public IList<string> Tags
        {
            get
            {
                if (_Tags == null)
                {
                    return new List<string>();
                }
                return _Tags.Split('|');
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
            _Tags = string.Join("|", tags.Distinct().OrderBy(t => t));
        }

        #endregion Tags: Add/Remove

        public override int GetHashCode()
        {
            return Tags.GetHashCode() ^ Thumbnail.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Properties))
                return false;

            return Equals((Properties)obj);
        }

        public bool Equals(Properties other)
        {
            if (_Tags != other._Tags ||
                _Thumbnail != other._Thumbnail)
                return false;

            return true;
        }

        public static bool operator ==(Properties item1, Properties item2)
        {
            return item1.Equals(item2);
        }

        public static bool operator !=(Properties item1, Properties item2)
        {
            return !item1.Equals(item2);
        }
    }
}