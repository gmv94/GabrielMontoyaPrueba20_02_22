﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using GabrielMontoyaPrueba20_02_22.Business;
using GabrielMontoyaPrueba20_02_22.Entities;
using GabrielMontoyaPrueba20_02_22.Models;

namespace GabrielMontoyaPrueba20_02_22.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InsertarDatosIniciales();
            }
        }


        private bool ValidarFormulario()
        {
            return true;
        }

        private void InsertarDatosIniciales()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            var resultadoConsulta = oDBPruebaSE.SpConsultarUsuario();
            if(resultadoConsulta.ToList().Count > 0)
            {
                lblConsult.Text = "Registros en la DB";
                lblConsult.Visible = true;
            }
            else
            {
                lblConsult.Text = "No hay registros en la DB";
                lblConsult.Visible = true;
            }
        }

        /// <summary>
        /// Consulta el usuario ingresado en los usuarios del API
        /// </summary>
        /// <returns></returns>
        private bool ConsultarUsuario()
        {
            UserBusiness objUser = new UserBusiness();
            List<UserEntities> users = objUser.DatosUser();
            foreach (var item in users)
            {
                if (item.userName == txtUser.Value
                    || item.password == txtPw.Value)
                    Session["id"] = item.id;
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Botón de acción que llama el método para consultar el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsult_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarFormulario())
                {
                    if(ConsultarUsuario())
                    {
                        lblConsult.Text = "El usuario existe!";
                        lblConsult.Visible = true;
                    }
                    else
                    {
                        lblConsult.Text = "Datos de usuario incorrectos";
                        lblConsult.Visible = true;
                    }
                }
                else
                {
                    lblConsult.Text = "Por favor ingrese los datos requeridos";
                    lblConsult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblConsult.Text = ex.Message;
                lblConsult.Visible = true;
            }
        }


    }
}