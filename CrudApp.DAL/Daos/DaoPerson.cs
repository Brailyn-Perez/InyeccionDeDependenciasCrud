using CrudApp.DAL.Context;
using CrudApp.DAL.Entities;
using CrudApp.DAL.Exceptions;
using CrudApp.DAL.Interfaces;
using CrudApp.DAL.Models.Person;
using Microsoft.Extensions.Logging;

namespace CrudApp.DAL.Daos
{
    public class DaoPerson : IDaoPerson
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DaoPerson> _logger;

        public DaoPerson(ApplicationDbContext dbContext, ILogger<DaoPerson> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        public void Create(PersonCreateModel personCreate)
        {
            try
            {
                if (personCreate is null)
                {
                    throw new DaoPersonException("No se pueden enviar personas nulas");
                }
                if (string.IsNullOrEmpty(personCreate.FirstName) || string.IsNullOrEmpty(personCreate.LastName))
                {
                    throw new DaoPersonException("El primer Nombre o Apellido es obligatorio");
                }
                if (personCreate.FirstName.Length >= 50)
                {
                    throw new DaoPersonException("No puedes poner un nombre de mas de 50 caracteres");
                }
                if (personCreate.LastName.Length >= 50)
                {
                    throw new DaoPersonException("No puedes enviar apellidos mayores a 50 caracteres");
                }
                if (personCreate.Email.Length >= 100
                    || personCreate.Phone.Length >= 15
                    || personCreate.Address.Length >= 255
                    || personCreate.City.Length >= 50
                    || personCreate.Country.Length >= 50
                    )
                {
                    throw new DaoPersonException("Hay datos que exceden el valor permitido");
                }
                Person person = new Person()
                {
                    FirstName = personCreate.FirstName,
                    LastName = personCreate.LastName,
                    Email = personCreate.Email,
                    Phone = personCreate.Phone,
                    BirthDate = personCreate.BirthDate,
                    Address = personCreate.Address,
                    City = personCreate.City,
                    Country = personCreate.Country,
                    CreateDate = DateTime.Now,
                    Deleted = false

                };

                _context.Persons.Add(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Creando la Persona", ex.ToString());
            }
        }

        public List<GetPersonModel> GetAll()
        {
            List<GetPersonModel> PersonasList = new List<GetPersonModel>();
            try
            {
                PersonasList = (from PersonasDatos in _context.Persons
                                where PersonasDatos.Deleted == false
                                select new GetPersonModel()
                                {
                                    Id =PersonasDatos.Id,
                                    FirstName = PersonasDatos.FirstName,
                                    LastName = PersonasDatos.LastName,
                                    Email = PersonasDatos.Email,
                                    Phone = PersonasDatos.Phone,
                                    BirthDate = PersonasDatos.BirthDate,
                                    Address = PersonasDatos.Address,
                                    City = PersonasDatos.City,
                                    Country = PersonasDatos.Country

                                }
                                ).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Buscando la lista de Personas",ex.ToString());
            }
            return PersonasList;
        }

        public GetPersonModel GetByID(int id)
        {
            var personById = _context.Persons.Find(id);
            GetPersonModel getPerson = new GetPersonModel();
            try
            {
                if (id <= 0)
                {
                    throw new DaoPersonException("El id no puede ser negativo");
                }
                if (personById is null)
                {
                    throw new DaoPersonException("Ocurrio un error encontrando la persona por id");
                }

                getPerson.Id = personById.Id;
                getPerson.FirstName = personById.FirstName;
                getPerson.LastName = personById.LastName;
                getPerson.Email = personById.Email;
                getPerson.Phone = personById.Phone;
                getPerson.BirthDate = personById.BirthDate;
                getPerson.Address = personById.Address;
                getPerson.City = personById.City;
                getPerson.Country = personById.Country;


            }
            catch (Exception ex)
            {
                _logger.LogError("Error buscando la persona por id", ex.ToString());
            }
            return getPerson;
        }

        public void Update(GetPersonModel personUpdate)
        {
            try
            {

                if (personUpdate is null)
                {
                    throw new DaoPersonException("No se pueden enviar personas nulas");
                }
                if (string.IsNullOrEmpty(personUpdate.FirstName) || string.IsNullOrEmpty(personUpdate.LastName))
                {
                    throw new DaoPersonException("El primer Nombre o Apellido es obligatorio");
                }
                if (personUpdate.FirstName.Length >= 50)
                {
                    throw new DaoPersonException("No puedes poner un nombre de mas de 50 caracteres");
                }
                if (personUpdate.LastName.Length >= 50)
                {
                    throw new DaoPersonException("No puedes enviar apellidos mayores a 50 caracteres");
                }
                if (personUpdate.Email.Length >= 100
                    || personUpdate.Phone.Length >= 15
                    || personUpdate.Address.Length >= 255
                    || personUpdate.City.Length >= 50
                    || personUpdate.Country.Length >= 50
                    )
                {
                    throw new DaoPersonException("Hay datos que exceden el valor permitido");
                }

                Person person = new Person()
                {
                    Id = personUpdate.Id,
                    FirstName = personUpdate.FirstName,
                    LastName = personUpdate.LastName,
                    Email = personUpdate.Email,
                    Phone = personUpdate.Phone,
                    BirthDate = personUpdate.BirthDate,
                    Address = personUpdate.Address,
                    City = personUpdate.City,
                    Country = personUpdate.Country,
                    UpdateDate = DateTime.Now,
                    Deleted = false
                };

                _context.Persons.Update(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error eliminado el registro", ex.ToString());
            }
        }

        public void Delete(GetPersonModel personRemove)
        {

            try
            {

                if (personRemove is null)
                {
                    throw new DaoPersonException("No puedes mandar personas nulas");
                }
                if (personRemove.Id <= 0)
                {
                    throw new DaoPersonException("El Id de una persona no puede ser negativo o 0");

                }

                var getPersonById = _context.Persons.FirstOrDefault(x => x.Id == personRemove.Id);

                if (getPersonById is null)
                {
                    throw new DaoPersonException("No se encontro la persona a eliminar");
                }
                else
                {
                    getPersonById.DeletedDate = DateTime.Now;
                    getPersonById.Deleted = true;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error eliminado el registro", ex.ToString());
            }

        }
    }
}
