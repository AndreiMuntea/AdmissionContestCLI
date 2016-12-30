using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Domain
{
   public class HasID<T>
   {
      public T ID { get;}
      
      public HasID(T ID)
      {
         this.ID = ID;
      }

      protected bool Equals(HasID<T> other)
      {
         return EqualityComparer<T>.Default.Equals(ID, other.ID);
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((HasID<T>) obj);
      }

      public override int GetHashCode()
      {
         return EqualityComparer<T>.Default.GetHashCode(ID);
      }

      public static bool operator ==(HasID<T> left, HasID<T> right)
      {
         return Equals(left, right);
      }

      public static bool operator !=(HasID<T> left, HasID<T> right)
      {
         return !Equals(left, right);
      }

      public override string ToString()
      {
         return $"{nameof(ID)}: {ID}";
      }
   }
}
