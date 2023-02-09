using Presentacion.Constantes;
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
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();
        }


        public virtual void Control_Enter(object sender, EventArgs e)
        {
            ///Recibe el foco
            ///
            if(sender is TextBox)
            {
                ((TextBox)sender).BackColor = ColoresSistema.ColorControlConFoco;
            }
        }

       public virtual void Control_Leave(object sender, EventArgs e)
        {
            //Piede el foco

            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = ColoresSistema.ColorControlSinFoco;
            }
        }
    }
}
