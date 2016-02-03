using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Person
    {
        public string DisplayName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;

            return Equals((Person)obj);
        }

        public bool Equals(Person other)
        {
            if (Firstname != other.Firstname || Lastname != other.Lastname)
                return false;

            return true;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }
    }
}