using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vbgCMS.Models
{
    public abstract class BaseEntity : IEquatable<long>
    {
        public virtual long Id { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((long)obj);
        }
        public virtual bool Equals(long other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return (this.GetHashCode() == other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
