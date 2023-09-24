using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using DataAccessLayer.Migrations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    {
        private DBContextCore _dbContext;

        public DAL_Vehiculos_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string matricula)
        {
           var vehiculoBorrar = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            if (vehiculoBorrar != null)
            {
                _dbContext.Vehiculos.Remove(vehiculoBorrar);
                _dbContext.SaveChanges();
            }
        }

        public List<Vehiculo> Get()
        {
            return _dbContext.Vehiculos
                             .Select(v => new Vehiculo { Marca = v.Marca, Modelo = v.Modelo, Matricula = v.Matricula, DocumentoPersona = v.Persona.Documento })
                             .ToList();
        }

        public Vehiculo Get(string matricula)
        {
            return _dbContext.Vehiculos
               .Where(v => v.Matricula == matricula)
               .Select(v => new Vehiculo { Marca = v.Marca, Modelo = v.Modelo, Matricula = v.Matricula, DocumentoPersona = v.Persona.Documento }).FirstOrDefault();
        }


        public void Insert(Vehiculo vehiculo)
        {
            var personaDuenio = _dbContext.Personas.FirstOrDefault(p => p.Documento == vehiculo.DocumentoPersona);
            var nuevoVehiculo = new Vehiculos
            {
                Matricula = vehiculo.Matricula,
                Modelo = vehiculo.Modelo,
                Marca = vehiculo.Marca,
                PersonaId = personaDuenio.Id

            };

            _dbContext.Vehiculos.Add(nuevoVehiculo);
            _dbContext.SaveChanges();
        }
        public void Update(Vehiculo vehiculo)
        {
            var personaDuenio = _dbContext.Personas.FirstOrDefault(p => p.Documento == vehiculo.DocumentoPersona);
            var vehiculoEditar = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == vehiculo.Matricula);
            if (vehiculoEditar != null)
            {
                vehiculoEditar.Matricula = vehiculo.Matricula;
                vehiculoEditar.Modelo = vehiculo.Modelo;
                vehiculoEditar.Marca = vehiculo.Marca;
                vehiculoEditar.PersonaId = personaDuenio.Id;
                _dbContext.SaveChanges();
            }
        }
    }
    
}