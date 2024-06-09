using Filmsammlung.Model;


namespace Filmsammlung.Services.Interfaces
{
    public interface INoteService
    {
        public Noten GeNoteById(int notenRequestedId);
        public IEnumerable<Noten> GetAllNoten();
        public Noten AddNote(Noten noten);
        public void UpdateNote(Noten noten);
        public bool DeleteNote(int id);
    }
}
