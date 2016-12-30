using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Domain
{
   public class Section : HasID<String>
   {
      public String Name { get; set; }
      public Int32 AvailableSlots { get; set; }

      public Section(String ID, String name, Int32 availableSlots) : base(ID)
      {
         Name = name;
         AvailableSlots = availableSlots;
      }

      protected bool Equals(Section other)
      {
         return base.Equals(other) && string.Equals(Name, other.Name) && AvailableSlots == other.AvailableSlots;
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((Section) obj);
      }

      public override int GetHashCode()
      {
           return base.GetHashCode();
      }

      public static bool operator ==(Section left, Section right)
      {
         return Equals(left, right);
      }

      public static bool operator !=(Section left, Section right)
      {
         return !Equals(left, right);
      }

      public override string ToString()
      {
         return $"{base.ToString()}, {nameof(Name)}: {Name}, {nameof(AvailableSlots)}: {AvailableSlots}";
      }
   }
}
