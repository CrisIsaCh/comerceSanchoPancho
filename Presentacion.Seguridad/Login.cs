using System;
using System.Windows.Forms;
using XCommerce.Servicio.Seguridad.Acceso;
using XCommerce.Servicio.Seguridad.Usuario;

namespace Presentacion.Seguridad
{
    public partial class Login : FormularioBase.FormularioBase
    {

        public bool PuedePasar { get; set; }

        private readonly IAccesoSeguridad _accesoSeguridad;

        private int _cantidadDeAccesosFallidos;

        private readonly IUsuarioServicio _usuarioServicio;


        public Login() 
       // :this(new AccesoSistema(),new UsuarioServicio())
        {
            InitializeComponent();
            _cantidadDeAccesosFallidos = 0;
            //Asignar los eventos
            txtUsuario.Enter += Control_Enter;
            txtUsuario.Leave += Control_Leave;

            txtPassword.Enter += Control_Enter;
            txtPassword.Leave += Control_Leave;

            //Asignar imagenes
            imgLogo1.Image = Constantes.Imagen.ImagenLogin;
            imgOjo.Image = Constantes.Imagen.ImagenOjoPassword;

        }

        public Login(IAccesoSeguridad accesoSeguridad, IUsuarioServicio usuarioServicio)
            : this()

        {
            _accesoSeguridad = accesoSeguridad;
            _usuarioServicio = usuarioServicio;
        }

        private void Login_Load(object sender, System.EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            if (ExistenDatosObligatorios())
            {
                //verifica si exite el usuario
                if (_accesoSeguridad.VerificarAcceso(txtUsuario.Text,txtPassword.Text))
                {
                    //verifico si Usuario esta bloqueado
                    if (!_accesoSeguridad.VerificarSiUsuarioEstaBloqueado(txtUsuario.Text))
                    {
                        PuedePasar = true;
                        this.Close();
                    }
                    else
                    {
                        //si esta bloqueado mostrar mensaje
                        MessageBox.Show("El Usuario Esta Bloqueado.");
                        txtPassword.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();

                    }
                }
                else
                {
                     
                    MessageBox.Show("El Usuario o la Contraseña son incorrectos");
                    txtPassword.Clear();
                    txtPassword.Focus();

                    _cantidadDeAccesosFallidos++;

                    if (_cantidadDeAccesosFallidos>=3)
                    {

                        try
                        {
                            _usuarioServicio.CambiarEstado(txtUsuario.Text, true);
                            MessageBox.Show(@"El  Ususario fue BLOQUEADO");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                        
                        Application.Exit();
                    }

                }
            }
            
        }

        private bool ExistenDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show(@"El Nombre del Usuario es Obligatorio");
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Lacontraseña es Obligatoria.");
                txtPassword   .Focus();
                return false;
            }

            return true;
        }
    }
}
