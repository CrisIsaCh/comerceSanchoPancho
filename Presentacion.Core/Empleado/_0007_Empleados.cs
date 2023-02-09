using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.core.Empleado;

namespace Presentacion.Core.Empleado
{
    public partial class _0007_Empleados : FormularioConsulta
    {

        private readonly IEmpleadoServicio _empleadoServicio;
        public _0007_Empleados()
        {
            InitializeComponent();
        }
    }
}
