using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            var personaBorrar = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (personaBorrar != null)
            {
                _dbContext.Personas.Remove(personaBorrar);
                _dbContext.SaveChanges();
            }
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { Documento = p.Documento, Nombre = p.Nombres, Apellido = p.Apellidos, Direccion = p.Direccion, FechaNacimiento = p.FechaNacimiento })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            return _dbContext.Personas
                .Where(p => p.Documento == documento)
                .Select(p => new Persona { Documento = p.Documento, Nombre = p.Nombres, Apellido = p.Apellidos, Direccion = p.Direccion, FechaNacimiento = p.FechaNacimiento }).FirstOrDefault();
        }

        public void Insert(Persona persona)
        {
            var nuevaPersona = new Personas
            {
                Documento = persona.Documento,
                Nombres = persona.Nombre,
                Apellidos = persona.Apellido,
                Direccion = persona.Direccion,
                FechaNacimiento = persona.FechaNacimiento
            };

            _dbContext.Personas.Add(nuevaPersona);
            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            var personaEditar = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if (personaEditar != null)
            {
                personaEditar.Nombres = persona.Nombre;
                personaEditar.Apellidos = persona.Apellido;
                personaEditar.Direccion = persona.Direccion;
                personaEditar.FechaNacimiento = persona.FechaNacimiento;
                personaEditar.Documento = persona.Documento;
                _dbContext.SaveChanges();
            }
        }
    }
}
