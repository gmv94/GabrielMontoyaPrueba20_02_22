using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GabrielMontoyaPrueba20_02_22.Models;
using GabrielMontoyaPrueba20_02_22.Entities;
using GabrielMontoyaPrueba20_02_22.Business;

namespace GabrielMontoyaPrueba20_02_22.Pages
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool validarFormulario()
        {
            if(ddlTipoConsulta.SelectedValue == "1")
            {
                return !string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtApellido.Text.Trim());
            }
            else
            {
                return !string.IsNullOrEmpty(txtLibro.Text.Trim());
            }
        }

        /// <summary>
        /// Consultar libros por nombre del libro
        /// </summary>
        private void ConsultarLibros2()
        {
            try
            {
                DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
                var ListData = oDBPruebaSE.SpConsultaPorLibro(txtLibro.Text);

                List<ConsultaLibroEntities> oListLibroGrid = new List<ConsultaLibroEntities>();
                ConsultaLibroEntities oListData;

                foreach (var item in ListData)
                {
                    oListData = new ConsultaLibroEntities();

                    oListData.title = item.title;
                    oListData.publishDate = item.publishDate;
                    oListData.pageCount = item.pageCount;
                    oListData.excerpt = item.excerpt;
                    oListData.Author = item.Author;
                    oListData.description = item.description;

                    oListLibroGrid.Add(oListData);
                }
                if (oListLibroGrid.Count > 0)
                {
                    gvwLibro.DataSource = oListLibroGrid;
                    gvwLibro.DataBind();
                }
                else
                {
                    lblConsult.Text = "No se encontraron registros";
                    lblConsult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblConsult.Text = ex.Message;
                lblConsult.Visible = true;
            }
        }

        /// <summary>
        /// Consultar libros por Autor
        /// </summary>
        private void ConsultarLibros1()
        {
            try
            {
                DBPruebaSEEntities oDBPruebaSE = new DBPruebaSEEntities();
                var ListData = oDBPruebaSE.SpConsultaPorAutor(txtNombre.Text, txtApellido.Text);

                List<ConsultaLibroEntities> oListAutorGrid = new List<ConsultaLibroEntities>();
                ConsultaLibroEntities oListData;

                foreach (var item in ListData)
                {
                    oListData = new ConsultaLibroEntities();

                    oListData.title = item.title;
                    oListData.publishDate = item.publishDate;
                    oListData.pageCount = item.pageCount;
                    oListData.excerpt = item.excerpt;
                    oListData.Author = item.Author;
                    oListData.description = item.description;

                    oListAutorGrid.Add(oListData);
                }
                if (oListAutorGrid.Count > 0)
                {
                    gvwLibro.DataSource = oListAutorGrid;
                    gvwLibro.DataBind();
                }
                else
                {
                    lblConsult.Text = "No se encontraron registros";
                    lblConsult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblConsult.Text = ex.Message;
                lblConsult.Visible = true;
            }
        }

        /// <summary>
        /// Dirigir al Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Login.aspx");
        }

        /// <summary>
        /// Botón que dirige al procedimiento almacenado dependiendo del tipo de consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if(validarFormulario())
            {
                if (ddlTipoConsulta.SelectedValue == "1")
                {
                    ConsultarLibros1();
                }
                else
                {
                    ConsultarLibros2();
                }
            }
            else
            {
                lblConsult.Text = "Por favor indicar los datos requeridos";
                lblConsult.Visible = true;
            }
            
        }

        /// <summary>
        /// Paginado para las consultas que soprepasen los 10 registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvwLibro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwLibro.PageIndex = e.NewPageIndex;
            if(ddlTipoConsulta.SelectedValue == "1")
            {
                ConsultarLibros1();
            }
            else
            {
                ConsultarLibros2();
            }
        }

        /// <summary>
        /// Habilita campos dependiendo el tipo de consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTipoConsulta.SelectedValue == "1")
            {

                dvAutor.Visible = true;
                dvLibro.Visible = false;
            }
            else
            {
                dvAutor.Visible = false;
                dvLibro.Visible = true;
            }
        }
    }

}