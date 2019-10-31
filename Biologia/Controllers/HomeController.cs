using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Biologia.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Biologia.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Insectos insecto)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string f1 = insecto.Fecha.ToString("dd/MM/yyyy");
                    

                   string sql = $"Insert Into Registro (Usuario,Reino,Phylum,Clase,Orden,Familia,Detalles,Taxa,Morfo,Abun,Frasco,Vegetacion,Metodo,Sustrato,Localida,Fecha,Longitud,Altitud) Values ('{insecto.usuario}','{insecto.reino}','{insecto.phyllum}','{insecto.clase}','{insecto.orden}','{insecto.familia}','{insecto.informacion}','{insecto.Taxa}','{insecto.Morfoespecie}','{insecto.Abundancia}','{insecto.NumFrasco}','{insecto.TipoVegetacion}','{insecto.MetodoColecta}','{insecto.Sustrato}','{insecto.Localidad}',CONVERT(datetime, '{f1}',103),'{insecto.Longitud}','{insecto.Altitud}')";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        Console.Write(insecto.Longitud);
                        Console.Write(insecto.Altitud);
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                    return RedirectToAction("List");
                }
            }
            else
                return View();
        }
        //ver
        public IActionResult List()
        {
            List<Insectos> insecto = new List<Insectos>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                connection.Open();

                string sql = "Select * From Registro"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Insectos insec = new Insectos();
                        insec.usuario = Convert.ToString(dataReader["Usuario"]);
                        insec.Id = Convert.ToInt32(dataReader["Id"]);
                        //insec.reino = Convert.ToString(dataReader["Reino"]);
                        //insec.phyllum = Convert.ToString(dataReader["Phylum"]);
                        //insec.clase = Convert.ToString(dataReader["Clase"]);
                        insec.orden = Convert.ToString(dataReader["Orden"]);
                        //insec.familia = Convert.ToString(dataReader["Familia"]);
                        //insec.informacion = Convert.ToString(dataReader["Detalles"]);
                        insec.Taxa = Convert.ToString(dataReader["Taxa"]);
                        insec.Morfoespecie = Convert.ToString(dataReader["Morfo"]);
                        insec.Abundancia = Convert.ToString(dataReader["Abun"]);
                        //insec.NumFrasco = Convert.ToInt32(dataReader["Frasco"]);
                        insec.TipoVegetacion = Convert.ToString(dataReader["Vegetacion"]);
                        insec.MetodoColecta = Convert.ToString(dataReader["Metodo"]);
                        insec.Sustrato = Convert.ToString(dataReader["Sustrato"]);
                        insec.Localidad = Convert.ToString(dataReader["Localida"]);
                        insec.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString());
                        insec.Longitud = Convert.ToString(dataReader["Longitud"]);
                        insec.Altitud = Convert.ToInt32(dataReader["Altitud"]);
                        insecto.Add(insec);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(insecto);
        }

        public IActionResult Update(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            Insectos insec = new Insectos();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From Registro Where Id='{id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        insec.usuario = Convert.ToString(dataReader["Usuario"]);
                        insec.Id = Convert.ToInt32(dataReader["Id"]);
                        insec.reino = Convert.ToString(dataReader["Reino"]);
                        insec.phyllum = Convert.ToString(dataReader["Phylum"]);
                        insec.clase = Convert.ToString(dataReader["Clase"]);
                        insec.orden = Convert.ToString(dataReader["Orden"]);
                        insec.familia = Convert.ToString(dataReader["Familia"]);
                        insec.informacion = Convert.ToString(dataReader["Detalles"]);
                        insec.Taxa = Convert.ToString(dataReader["Taxa"]);
                        insec.Morfoespecie = Convert.ToString(dataReader["Morfo"]);
                        insec.Abundancia = Convert.ToString(dataReader["Abun"]);
                        insec.NumFrasco = Convert.ToInt32(dataReader["Frasco"]);
                        insec.TipoVegetacion = Convert.ToString(dataReader["Vegetacion"]);
                        insec.MetodoColecta = Convert.ToString(dataReader["Metodo"]);
                        insec.Sustrato = Convert.ToString(dataReader["Sustrato"]);
                        insec.Localidad = Convert.ToString(dataReader["Localida"]);
                        insec.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString());
                        insec.Longitud = Convert.ToString(dataReader["Longitud"]);
                        insec.Altitud = Convert.ToInt32(dataReader["Altitud"]);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(insec);
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update(Insectos insecto)
        {
            string f1 = insecto.Fecha.ToString("dd/MM/yyyy");
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Registro SET Usuario='{insecto.usuario}' , Reino='{insecto.reino}',Phylum='{insecto.phyllum}',Clase='{insecto.clase}',Orden='{insecto.orden}',Familia='{insecto.familia}',Detalles='{insecto.informacion}', Taxa='{insecto.Taxa}',Morfo='{insecto.Morfoespecie}', Abun='{insecto.Abundancia}',Frasco='{insecto.NumFrasco}',Vegetacion='{insecto.TipoVegetacion}',Metodo='{insecto.MetodoColecta}',Sustrato='{insecto.Sustrato}' ,Localida='{insecto.Localidad}',Fecha='{f1}' ,Longitud='{insecto.Longitud}',Altitud='{insecto.Altitud}' Where Id='{insecto.Id}'";
                                                                                                                                                                                                              
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
            }
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            Insectos insec = new Insectos();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From Registro Where Id='{id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        insec.usuario = Convert.ToString(dataReader["Usuario"]);
                        insec.Id = Convert.ToInt32(dataReader["Id"]);
                        insec.reino = Convert.ToString(dataReader["Reino"]);
                        insec.phyllum = Convert.ToString(dataReader["Phylum"]);
                        insec.clase = Convert.ToString(dataReader["Clase"]);
                        insec.orden = Convert.ToString(dataReader["Orden"]);
                        insec.familia = Convert.ToString(dataReader["Familia"]);
                        insec.informacion = Convert.ToString(dataReader["Detalles"]);
                        insec.Taxa = Convert.ToString(dataReader["Taxa"]);
                        insec.Morfoespecie = Convert.ToString(dataReader["Morfo"]);
                        insec.Abundancia = Convert.ToString(dataReader["Abun"]);
                        insec.NumFrasco = Convert.ToInt32(dataReader["Frasco"]);
                        insec.TipoVegetacion = Convert.ToString(dataReader["Vegetacion"]);
                        insec.MetodoColecta = Convert.ToString(dataReader["Metodo"]);
                        insec.Sustrato = Convert.ToString(dataReader["Sustrato"]);
                        insec.Localidad = Convert.ToString(dataReader["Localida"]);
                        insec.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString());
                        insec.Longitud = Convert.ToString(dataReader["Longitud"]);
                        insec.Altitud = Convert.ToInt32(dataReader["Altitud"]);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(insec);
        }

        [HttpPost]
        [ActionName ("Delete")]
        public IActionResult Delet(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From Registro Where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        ViewBag.Result = "No se pudo eliminar el dato solicitado:" + ex.Message;
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            return RedirectToAction("List");
        }


        public IActionResult Details(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            Insectos insec = new Insectos();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From Registro Where Id='{id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        insec.usuario = Convert.ToString(dataReader["Usuario"]);
                        insec.Id = Convert.ToInt32(dataReader["Id"]);
                        insec.reino = Convert.ToString(dataReader["Reino"]);
                        insec.phyllum = Convert.ToString(dataReader["Phylum"]);
                        insec.clase = Convert.ToString(dataReader["Clase"]);
                        insec.orden = Convert.ToString(dataReader["Orden"]);
                        insec.familia = Convert.ToString(dataReader["Familia"]);
                        insec.informacion = Convert.ToString(dataReader["Detalles"]);
                        insec.Taxa = Convert.ToString(dataReader["Taxa"]);
                        insec.Morfoespecie = Convert.ToString(dataReader["Morfo"]);
                        insec.Abundancia = Convert.ToString(dataReader["Abun"]);
                        insec.NumFrasco = Convert.ToInt32(dataReader["Frasco"]);
                        insec.TipoVegetacion = Convert.ToString(dataReader["Vegetacion"]);
                        insec.MetodoColecta = Convert.ToString(dataReader["Metodo"]);
                        insec.Sustrato = Convert.ToString(dataReader["Sustrato"]);
                        insec.Localidad = Convert.ToString(dataReader["Localida"]);
                        insec.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString());
                        insec.Longitud = Convert.ToString(dataReader["Longitud"]);
                        insec.Altitud = Convert.ToInt32(dataReader["Altitud"]);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(insec);
        }


        //Fin
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
