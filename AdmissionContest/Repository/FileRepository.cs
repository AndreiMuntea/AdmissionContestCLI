using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Helper.Loader;
using AdmissionContest.Helper.Saver;

namespace AdmissionContest.Repository
{
   public class FileRepository<ID, E> : AbstractRepository<ID, E> where E:HasID<ID>
   {
      private readonly ILoader<E> _loader;
      private readonly ISaver<E> _saver;
      private readonly string _fileName;

      public FileRepository(ILoader<E> loader, ISaver<E> saver, string fileName)
      {
         _loader = loader;
         _saver = saver;
         _fileName = fileName;

         LoadFromFile();
      }

      public override void AddElement(E element)
      {
         base.AddElement(element);
         _saver.SaveData(_fileName,GetAll());
      }

      public override void RemoveElement(ID id)
      {
         base.RemoveElement(id);
         _saver.SaveData(_fileName,GetAll());
      }

      public override void UpdateElement(ID id, E updatedElement)
      {
         base.UpdateElement(id, updatedElement);
         _saver.SaveData(_fileName,GetAll());
      }


      protected void LoadFromFile()
      {
         AddAll(_loader.LoadData(_fileName));
      }
   }
}
