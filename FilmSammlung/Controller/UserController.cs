using Microsoft.AspNetCore.Mvc;
using Filmsammlung.Services.Interfaces;
using Filmsammlung.Model;

namespace FilmSammlung.Controllers
{
    /// <summary>
    /// Der UserController beschreibt, wie mit dem Endpunkt User interagiert werden kann
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :Controller
    {
        private IUserService userService;
        public UserController(IUserService userServices)
        {
            userService = userServices;
        }
        /// <summary>
        /// Gibt alle User zurück
        /// </summary>
        /// <returns>Liste der Users</returns>
        /// <response code="204">Keine User wurden gefunden</response>
        [HttpGet()]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<User> Get()
        {
            try
            {
                var users = userService.GetAllUsers();
                if (users.Count() == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, users);
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
        /// <summary>
        /// Gibt alle Noten eines Users zurück
        /// </summary>
        /// <returns>Liste von Noten</returns>
        /// <response code="204">Keine Noten wurden gefunden</response>
        [HttpGet("AllNotenByUserId")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Noten> GetAllNotenByUserId([FromRoute] int Id)
        {
            try
            {
                var noten = userService.GetAllNotenByUserId(Id);
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
        /// Erstellt einen User
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns>Neuer User</returns>
        /// <response code="200">Gibt den neuen User zurück</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<User> Create([FromBody] User userRequest)
        {
            User createdUser;
            try
            {
                createdUser = userService.AddUser(userRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User has not been created");
            }
            return Ok(createdUser);
        }
        /// <summary>
        /// Aktualisiert einen User
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns>Aktualisierten User</returns>
        /// <response code="200">User wurde aktualisiert</response>
        /// <response code="400">Es wurde kein gültiger User mitgegeben</response>
        /// <response code="404">Es wurde kein User zum Aktualisieren gefunden</response>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> Update([FromBody] User userRequest)
        {
            if (userRequest == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No User to be updated");
            }
            try
            {
                var user = userService.GetUserById(userRequest.Id);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No User found");
                }
                
                user.notenListe = userRequest.notenListe;
                user.Upn = userRequest.Upn;
                user.Id = userRequest.Id;

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User has not been updated");
            }
        }
        /// <summary>
        /// Löscht einen User
        /// </summary>
        /// <param name="Id">ID des Users der gelöscht wird</param>
        /// <returns></returns>
        /// <response code="204">Kein User wurde gefunden</response>
        /// <response code="400">Kein gültiger Request</response>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Delete([FromRoute] int Id)
        {
            try
            {
                var succeeded = userService.DeleteUser(Id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "User has not been deleted");
            }
        }
    }
}
