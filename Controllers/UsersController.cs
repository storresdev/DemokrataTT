using Microsoft.AspNetCore.Mvc;
using DemokrataTT.Models;
using DemokrataTT.Models.UserDtos;
using DemokrataTT.Repository.IRepository;
using AutoMapper;
using System.Net;
using DemokrataTT.Models.Entities;
using DemokrataTT.Pagination;

namespace DemokrataTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        protected Response _response = new();

        /// <summary>
        /// Método Get para obtener todos los ususarios
        /// </summary>
        /// <returns>Lista de todos los usuarios</returns>
        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response>> GetUsers()
        {
            try
            {
                IEnumerable<User> usersList = await _userRepository.GetListData();
                _response.Result = _mapper.Map<IEnumerable<UserDto>>(usersList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorsMessage = [ex.Message.ToString()];
            }

            return _response;
        }

        /// <summary>
        /// Método para obtener un usuario por Id
        /// </summary>
        /// <param name="id">Identificador del usuario</param>
        /// <returns>Objeto Usuario entonctrado</returns>
        // GET: api/Users/5
        [HttpGet("id:int", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> GetUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSucces = false;
                    return BadRequest(_response);
                }

                var user = await _userRepository.GetData(x => x.Id == id);

                if (user == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSucces = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<UserDto>(user);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorsMessage = [ex.ToString()];
            }

            return _response;
        }

        /// <summary>
        /// Método para buscar por cualquiera de los campos, nombre o apellido, 
        /// pasando además parametros para paginación de resultados.
        /// </summary>
        /// <param name="firstName">Nombre del usuario</param>
        /// <param name="lastName">Apellido del usuario</param>
        /// <param name="pageIndex">Número de la páginas</param>
        /// <param name="pageSize">Número de registros por página</param>
        /// <returns>Lista de usuarios</returns>
        // GET: api/Users/name/lastname/pageIndex/pageSixe
        [HttpGet("{firstName}/{lastName}/{pageIndex}/{pageSize}", Name = "GetUserByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> GetUserByName(string firstName = "", string lastName = "", int pageIndex = 1, int pageSize = 5)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSucces = false;
                    _response.ErrorsMessage = ["Debe especifiar un parametro de busqueda."];
                    return BadRequest(_response);
                }

                var paginationParams = new PaginationParams() { PageNumber = pageIndex, PageSize = pageSize, OrderAsc = true };
                var user = await _userRepository.GetPagination(x => x.FirstName == firstName || x.LastName == lastName, paginationParams);

                if (user == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSucces = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<IEnumerable<UserDto>>(user);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorsMessage = [ex.ToString()];
            }

            return _response;
        }

        /// <summary>
        /// Método para crear usuarios
        /// </summary>
        /// <param name="userCreateDto">Objeto usuario a crear</param>
        /// <returns>Redirige a consultar el usuario creado</returns>
        // POST: api/Users        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response>> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSucces = false;
                    return BadRequest(_response);
                }

                var userExist = await _userRepository.GetData(x => x.FirstName == userCreateDto.FirstName);
                if (userExist != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorsMessage = ["Ya existe un usuario con este nombre."];
                    _response.IsSucces = false;
                    return BadRequest(_response);
                }

                if (userCreateDto == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                User model = _mapper.Map<User>(userCreateDto);
                model.CreationDate = DateTime.Now;
                model.ModificationDate = DateTime.Now;

                await _userRepository.Create(model);
                _response.Result = model;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetUser", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorsMessage = [ex.ToString()];
            }

            return _response;
        }

        /// <summary>
        /// Método para actualizar un usuario por Id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="userUpdateDto">Objeto del usuario con datos a actualizar</param>
        /// <returns>Objeto del usuario actualizado</returns>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            try
            {
                if (userUpdateDto == null || id != userUpdateDto.Id)
                {
                    _response.IsSucces = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                User model = _mapper.Map<User>(userUpdateDto);

                await _userRepository.Update(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorsMessage = [ex.Message.ToString()];
            }

            return BadRequest(_response);
        }

        /// <summary>
        /// Método de eliminación de usuario por Id
        /// </summary>
        /// <param name="id">Id del ususario a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSucces = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var user = await _userRepository.GetData(x => x.Id == id);

                if (user == null)
                {
                    _response.IsSucces = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorsMessage = ["Elemento no encontrado"];
                    return NotFound(_response);
                }

                await _userRepository.Remove(user);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorsMessage = [ex.Message.ToString()];
            }

            return BadRequest(_response);
        }
    }
}