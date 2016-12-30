using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.RepositoryExceptions;
using AdmissionContest.Helper.EventFramework;

namespace AdmissionContest.Repository
{
   public abstract class  AbstractRepository<ID,E> : CustomEvent<E>, IRepository<ID, E> where E : HasID<ID>
   {
      protected readonly Dictionary<ID, E> _items;
      protected AbstractRepository()
      {
         _items = new Dictionary<ID, E>();
      }

      public virtual E GetElement(ID id)
      {
         if(!Exists(id)) throw new RepositoryNotFoundException($"Item with id {id} not found!\n");
         return _items[id];
      }

      public virtual void AddElement(E element)
      {
         if(Exists(element.ID)) throw new RepositoryDuplicateEntry($"Item with id {element.ID} already exists!\n");
         FireEvent(new CustomEventArgs<E>("Insert", element));
         _items.Add(element.ID, element);
      }

      public virtual void RemoveElement(ID id)
      {
         if (!Exists(id)) throw new RepositoryNotFoundException($"Item with id {id} not found!\n");
         FireEvent(new CustomEventArgs<E>("Delete",_items[id]));
         _items.Remove(id);
      }

      public virtual void UpdateElement(ID id, E updatedElement)
      {
         if (!Exists(id)) throw new RepositoryNotFoundException($"Item with id {id} not found!\n");
         FireEvent(new CustomEventArgs<E>("Update", updatedElement));
         _items[id] = updatedElement;
      }

      public virtual bool Exists(ID id)
      {
         return _items.ContainsKey(id);
      }

      public virtual ICollection<E> GetAll()
      {
         return _items.Values;
      }

      public virtual void AddAll(ICollection<E> collection)
      {
         foreach (var e in collection)
         {
            AddElement(e);
         }
      }

   }
}
