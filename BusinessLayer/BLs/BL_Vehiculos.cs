using BusinessLayer.IBLs;
using DataAccessLayer.DALs;
using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLs
{
    public class BL_Vehiculos : IBL_Vehiculos
    {
        private IDAL_Vehiculos _vehiculos;

        public BL_Vehiculos(IDAL_Vehiculos vehiculos)
        {
            _vehiculos = vehiculos;
        }
        public List<Vehiculo> Get()
        {
            return _vehiculos.Get();
        }
        public Vehiculo Get(string matricula)
        {
            return _vehiculos.Get(matricula);
        }
        public void Insert(Vehiculo vehiculo)
        {
            _vehiculos.Insert(vehiculo);
        }
        public void Update(Vehiculo vehiculo)
        {
            _vehiculos.Update(vehiculo);
        }
        public void Delete(String vehiculo)
        {
            _vehiculos.Delete(vehiculo);
        }
    }
  
}
