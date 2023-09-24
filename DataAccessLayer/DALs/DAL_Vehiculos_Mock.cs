using DataAccessLayer.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Vehiculos_Mock : IDAL_Vehiculos
    {
        private Dictionary<string, Vehiculo> vehiculos = new Dictionary<string, Vehiculo>();

        public List<Vehiculo> Get()
        {
            return vehiculos.Values.ToList();
        }

        public Vehiculo Get(string matricula)
        {
            return vehiculos[matricula];
        }

        public void Insert(Vehiculo vehiculo)
        {
            vehiculos.Add(vehiculo.Matricula, vehiculo);
        }

        public void Update(Vehiculo vehiculo)
        {
            vehiculos[vehiculo.Matricula] = vehiculo;
        }

        public void Delete(string matricula)
        {
            vehiculos.Remove(matricula);
        }
    }
}
