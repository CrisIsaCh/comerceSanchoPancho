using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.core.Empleado.DTOs;

namespace XCommerce.Servicio.core.Empleado
{
    public interface IEmpleadoServicio
    {
        IEnumerable<EmpleadoDto> Obtener(string cadenaBuscar);


    }
}
