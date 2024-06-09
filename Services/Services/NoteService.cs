using System;
using System.Collections.Generic;
using System.Linq;
using Filmsammlung.Data;
using Filmsammlung.Model;
using Filmsammlung.Services.Interfaces;

namespace Filmsammlung.Services.Services
{
    public class NoteService: INoteService
    {
        private readonly IGenericRepository genericRepository;
        public NoteService(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public Noten AddNote(Noten noten)
        {
            genericRepository.Insert(noten);
            return noten;
        }

        public bool DeleteNote(int id)
        {
            var noten = genericRepository.GetById<Noten>(id);
            if(noten == null)
            {
                return false;
            }
            genericRepository.Delete(noten);
            return true;
        }

        public Noten GeNoteById(int noteRequestedId)
        {
            return genericRepository.GetById<Noten>(noteRequestedId);
        }

        public IEnumerable<Noten> GetAllNoten()
        {
            return  genericRepository.GetAll<Noten>();
        }

        public void UpdateNote(Noten noten)
        {
            genericRepository.Update(noten);
        }
    }
}
