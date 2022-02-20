using System;
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
            return !string.IsNullOrEmpty(txtUser.Value.Trim())
                && !string.IsNullOrEmpty(txtPw.Value.Trim());
        }

        /// <summary>
        /// Llenar datos en la base de datos
        /// </summary>
        private void InsertarDatosIniciales()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            var resultadoConsulta = oDBPruebaSE.SpConsultarUsuario();
            if(resultadoConsulta.ToList().Count == 0)
            {
                insertarUsuarios();
                insertarLibros();
                insertarAutor();
                insertarCoverPhoto();
                insertarActividades();
            }
        }

        /// <summary>
        /// Insertar información de User en la base de datos (SQL Server)
        /// </summary>
        private void insertarUsuarios()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            UserBusiness objUser = new UserBusiness();
            List<UserEntities> users = objUser.DatosUser();

            foreach (var item in users)
            {
                oDBPruebaSE.SpInsertarUser(item.id, item.userName, item.password);
            }
        }

        /// <summary>
        /// Insertar información de Book en la base de datos (SQL Server)
        /// </summary>
        private void insertarLibros()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            BookBusiness objBook = new BookBusiness();
            List<BookEntities> books = objBook.DatosBook();

            foreach (var item in books)
            {
                oDBPruebaSE.SpInsertarBook(item.id, item.title, item.description, item.pageCount, item.excerpt, item.publishDate);
            }
        }

        /// <summary>
        /// Insertar información de CoverPhoto en la base de datos (SQL Server)
        /// </summary>
        private void insertarCoverPhoto()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            CoverPhotoBusiness objPhoto = new CoverPhotoBusiness();
            List<CoverPhotoEntities> coverPhotos = objPhoto.DatosCoverPhoto();

            foreach (var item in coverPhotos)
            {
                oDBPruebaSE.SpInsertarCoverPhoto(item.id, item.idBook, item.url);
            }
        }

        /// <summary>
        /// Insertar información de Author en la base de datos (SQL Server)
        /// </summary>
        private void insertarAutor()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            AuthorBusiness objAutor = new AuthorBusiness();
            List<AuthorEntities> authors = objAutor.DatosAuthor();

            foreach (var item in authors)
            {
                oDBPruebaSE.SpAuthor(item.id, item.idBook, item.firstName, item.lastName);
            }
        }

        /// <summary>
        /// Insertar información de Activity en la base de datos (SQL Server)
        /// </summary>
        private void insertarActividades()
        {
            DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
            ActivityBusiness objActividades = new ActivityBusiness();
            List<ActivityEntities> activities = objActividades.DatosActivity();

            foreach (var item in activities)
            {
                oDBPruebaSE.SpInsertarActivity(item.id, item.title, item.dueDate, item.completed);
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
                        Response.Redirect("/Pages/Consultas.aspx");
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