using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Domain
{
   public class Candidate : HasID<Int32>
   {
      public String Name{ get; set; }
      public String PhoneNumber { get; set; }
      public Double Grade { get; set; }
      public String Address { get; set; }

      public Candidate(Int32 ID, String name, String phoneNumber, Double grade, String address) : base(ID)
      {
         Name = name;
         PhoneNumber = phoneNumber;
         Grade = grade;
         Address = address;
      }

      protected bool Equals(Candidate other)
      {
         return string.Equals(Name, other.Name) && string.Equals(PhoneNumber, other.PhoneNumber) && Grade.Equals(other.Grade) && string.Equals(Address, other.Address);
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((Candidate) obj);
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public static bool operator ==(Candidate left, Candidate right)
      {
         return Equals(left, right);
      }

      public static bool operator !=(Candidate left, Candidate right)
      {
         return !Equals(left, right);
      }

      public override string ToString()
      {
         return $"{base.ToString()}, {nameof(Name)}: {Name}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Grade)}: {Grade}, {nameof(Address)}: {Address}";
      }
   }
}
