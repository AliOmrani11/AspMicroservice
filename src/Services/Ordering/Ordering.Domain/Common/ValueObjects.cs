using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public abstract class ValueObjects
    {
        protected static bool EqualOperator(ValueObjects left, ValueObjects right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return left?.Equals(right) != false;
        }

        protected static bool NotEqualOperator(ValueObjects left, ValueObjects right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType()!=this.GetType())
            {
                return false;
            }
            var other = (ValueObjects)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(s => s != null ? s.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
