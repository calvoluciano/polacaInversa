﻿using PagoAgilFrba.Modelo;
using PagoAgilFrba.SeleccionarFuncionalidad;
using PagoAgilFrba.SeleccionarRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class UsuarioForm : ReturnForm
    {
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            String usuario = textBox1.Text;

            byte[] contrasenia = Usuario.encriptar(textBox2.Text);                        // encripto la contraseña

            try
            {
                DB.correrProcedimiento("SPLOGIN", "usuario", usuario, "contrasenia", contrasenia);  // corro procedimiento de login

                Usuario.cargar(usuario);                                                            // cargo el usuario seleccionado

                List<Rol> roles = Usuario.getRoles();   // consigo los roles del usuario
                List<Sucursal> sucursales = Usuario.getSucursales();                   
                int cantidadDeRoles = roles.Count;
                int cantidadDeSucursales = sucursales.Count;

                if (cantidadDeRoles == 0) Error.show("El usuario seleccionado no tiene ningún rol asignado!");  // si no tiene roles muestro un error
                else if (cantidadDeRoles > 1)                                                                   // si tiene mas de uno doy a elegir
                {
                    if (cantidadDeSucursales <= 1)
                    {
                        if (cantidadDeSucursales == 1)
                            Usuario.sucursalSeleccionada = Usuario.getSucursales().First();

                        new SeleccionarRolForm(this).abrir();
                    }
                    else
                        new SeleccionarRolYSucursalForm(this).abrir();
                }
                else
                {   
                    // caso contrario elijo el unico directamente
                    Rol.rolSeleccionado = roles.First();
                    if (cantidadDeSucursales <= 1)
                    {
                        if (cantidadDeSucursales == 1)
                            Usuario.sucursalSeleccionada = Usuario.getSucursales().First();

                        new SeleccionarFuncionalidadForm(this).abrir();
                    }
                    else
                        new SeleccionarSucursalForm(this).abrir();
                }
            }
            catch (SqlException) { }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
