using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace PhotoLibrary
{
    [DataContract]
    public class Settings

    {
        [DataMember(Name = "InitialDirectory")]
        private string InitialDirectory { get; set; }

        [DataMember(Name = "Ignored")]
        public List<string> Ignored { get; set; }

        public Settings(string initialDirectory)
        {
            this.InitialDirectory = initialDirectory;
            this.Ignored = new List<string>();
        }

        public string GetDirectory { get { return InitialDirectory + Path.DirectorySeparatorChar; } }

        public string GetFile(string file)
        {
            return GetDirectory + file;
        }
    }
}