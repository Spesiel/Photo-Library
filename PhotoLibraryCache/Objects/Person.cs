using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Person
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;

            return Equals((Person)obj);
        }

        public bool Equals(Person other)
        {
            if (FirstName != other.FirstName || LastName != other.LastName)
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