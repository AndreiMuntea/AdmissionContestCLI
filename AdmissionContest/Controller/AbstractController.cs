using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Repository;
using AdmissionContest.Validator;

namespace AdmissionContest.Controller
{
   public abstract class AbstractController<ID, E> where E:HasID<ID>
   {
      protected readonly IRepository<ID, E> _repository;
      protected readonly IValidator<E> _validator;

      protected AbstractController(IRepository<ID, E> repository, IValidator<E> validator)
      {
         _repository = repository;
         _validator = validator;
      }

      public virtual void AddElement(params string[] arguments)
      {
         var element = GetEntityFromFormat(arguments);
         _validator.Validate(element);
         _repository.AddElement(element);
      }

      public virtual void RemoveEntity(params string[] arguments)
      {
         var id = GetIDFromFormat(arguments);
         _repository.RemoveElement(id);
      }

      public virtual void UpdateEntity(params string[] arguments)
      {
         var element = GetEntityFromFormat(arguments);
         _validator.Validate(element);
         _repository.UpdateElement(element.ID, element);
      }

      public ICollection<E> GetAll()
      {
         return _repository.GetAll();
      }

      public abstract E GetEntityFromFormat(params string[] format);

      public abstract ID GetIDFromFormat(params string[] format);
   }
}
