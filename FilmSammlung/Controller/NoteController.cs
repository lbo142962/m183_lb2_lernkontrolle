using Microsoft.AspNetCore.Mvc;
using Filmsammlung.Services.Interfaces;
using Filmsammlung.Model;


namespace FilmSammlung.Controllers
{
    /// <summary>
    /// Der NoteController beschreibt, wie mit dem Endpunkt Note interagiert werden kann
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private INoteService noteService;
        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }
        /// <summary>
        /// Gibt alle Noten zurück
        /// </summary>
        /// <returns>Liste der Noten</returns>
        /// <response code="204">Keine Noten wurden gefunden</response>
        [HttpGet()]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Noten> Get()
        {
            try
            {
                var noten = noteService.GetAllNoten();
                if (noten.Count() == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, noten);
                }
                return Ok(noten);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
        /// <summary>
        /// Erstellt neue Note
        /// </summary>
        /// <param name="notenRequested"></param>
        /// <returns>Neue Note</returns>
        /// <response code="200">Gibt die neue Note zurück</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Noten> Create([FromBody] Noten notenRequested)
        {
            Noten createdNoten;
            try
            {
                createdNoten = noteService.AddNote(notenRequested);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Note has not been created");
            }
            return Ok(createdNoten);
        }
        /// <summary>
        /// Aktualisiert eine Note
        /// </summary>
        /// <param name="noteRequested"></param>
        /// <returns>Aktualisierte Note</returns>
        /// <response code="200">Note wurde aktualisiert</response>
        /// <response code="400">Es wurde keine gültige Note übergeben</response>
        /// <response code="404">Es wurde keine Note zum Aktualisieren gefunden</response>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Noten> Update([FromBody] Noten noteRequested)
        {
            if (noteRequested == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No Note to be updated");
            }
            try
            {
                var note = noteService.GeNoteById(noteRequested.Id);
                if (note == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No Note found");
                }
                note.Id = noteRequested.Id;
                note.userId = noteRequested.userId;
                note.User = noteRequested.User;

                noteService.UpdateNote(note);
                return Ok(note);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Note has not been updated");
            }
        }
        /// <summary>
        /// Löscht eine Note
        /// </summary>
        /// <param name="Id">ID der Note die gelöscht wird</param>
        /// <returns></returns>
        /// <response code="204">Keine Note wurde gefunden</response>
        /// <response code="400">Kein gültiger Request</response>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Delete([FromRoute] int Id)
        {
            try
            {
                var succeeded = noteService.DeleteNote(Id);
                if (succeeded)
                {
                    return StatusCode(StatusCodes.Status204NoContent, true);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, false);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Note has not been deleted");
            }
        }
    }
}
