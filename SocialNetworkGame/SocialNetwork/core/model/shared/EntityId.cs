using System;

namespace SocialNetwork.core.model.shared
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class EntityId : IEquatable<EntityId>, IComparable<EntityId>
    {
        protected Object ObjValue { get; }

        public String Value { get; set; }

        protected EntityId()
        {
            // for ORM
        }

        protected EntityId(Object value)
        {
            if (value is string otherValue)

                ObjValue = otherValue;

            else
                ObjValue = value;

            Value = ObjValue.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is EntityId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public bool Equals(EntityId other)
        {
            if (other == null)
                return false;
            if (this.GetType() != other.GetType())
                return false;
            return this.Value == other.Value;
        }

        public int CompareTo(EntityId other)
        {
            if (other == null)
                return -1;

            return String.Compare(Value, other.Value, StringComparison.Ordinal);
        }

        public static bool operator ==(EntityId obj1, EntityId obj2)
        {
            if (object.Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(EntityId x, EntityId y)
        {
            return !(x == y);
        }
    }
}