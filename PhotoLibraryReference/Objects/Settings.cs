using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;

namespace PhotoLibrary.Reference.Objects
{
    [DataContract]
    public class Settings
    {
        [DataMember(Name = "InitialDirectory")]
        private string InitialDirectory { get; set; }

        [DataMember(Name = "Ignored")]
        public Collection<string> Ignored { get; internal set; }

        public Settings(string initialDirectory)
        {
            this.InitialDirectory = initialDirectory;
            this.Ignored = new Collection<string>();
        }

        public void SetIgnored(IList<string> value)
        {
            Ignored = new Collection<string>(value);
        }

        public string GetDirectory { get { return InitialDirectory + Path.DirectorySeparatorChar; } }

        public string GetFile(string file)
        {
            return GetDirectory + file;
        }
    }
}