using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IBLs
{
    public interface IBL_Vehiculos
    {
        List<Vehiculo> Get();

        Vehiculo Get(string matricula);

        void Insert(Vehiculo vehiculo);

        void Update(Vehiculo vehiculo);

        void Delete(string matricla);
    }
}
