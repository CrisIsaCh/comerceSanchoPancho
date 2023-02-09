using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Empleado
{
    public partial class _0007_Empleados
    {
        public override void ActualizarDatos(DataGridView grilla, string cadenabuscar)
        {
            grilla.DataSource = _empleadoServicio.Obtener(cadenabuscar); 
        }
    }
}
