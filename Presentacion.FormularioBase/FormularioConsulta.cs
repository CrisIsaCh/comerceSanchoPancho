using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.FormularioBase
{
    public partial class FormularioConsulta : FormularioBase
    {
        protected long? EntidadId;

        protected bool PuedeEjecutarComando;

        public FormularioConsulta()
        {
            InitializeComponent();
                //asiganacion de imagenes botones
            btnNuevo.Image = Constantes.Imagen.ImagenBotonNuevo;
            btnActualizar.Image = Constantes.Imagen.ImagenBotonActualizar;

            //asignamos los colores
            menuAccesoRapido.BackColor = Constantes.ColoresSistema.ColorMenu;

            //inicializamos variables
            EntidadId = null;
            PuedeEjecutarComando = false;


        }

        private bool HayDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarNuevo();
        }

        public virtual void EjecutarNuevo()
        {
            
        }

        //==================================================================================

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EjecutarEliminar();
        }

        public virtual void EjecutarEliminar()
        {
            //verifica si hay datos cargados
            if (HayDatosCargados())
            {
                //Si no tiene un valor selecionado
                if (!EntidadId.HasValue) 
                {
                    MessageBox.Show("Por favor selecione un registro");
                    PuedeEjecutarComando = false;
                    return;
                }

                PuedeEjecutarComando = true;
            }
            else
            {
                MessageBox.Show("No hay datos cargados");
            }
        }

        //============================================================================//

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EjecutarModificar();
        }

        public virtual void EjecutarModificar()
        {


            //verifica si hay datos cargados
            if (HayDatosCargados())
            {
                //Si no tiene un valor selecionado
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show("Por favor selecione un registro");
                    PuedeEjecutarComando = false;
                    return;
                }

                PuedeEjecutarComando = true;
            }
            else
            {
                MessageBox.Show("No hay datos cargados");
            }
        }


        
        //=====================================================================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,txtBuscar.Text);
        }

        public virtual void ActualizarDatos(DataGridView grilla,string cadenabuscar)
        {
            
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        public  virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatosCargados())
            {
                EntidadId = (long?) dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                EntidadId = null;
            }
        }
    }
}
