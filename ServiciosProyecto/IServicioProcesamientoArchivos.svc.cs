﻿using Dominio;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosProyecto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioProcesamientoArchivos : IServicioProcesamientoArchivos
    {
            private RepositorioProyectos repoProyectos = new RepositorioProyectos();
            private string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos");
            public int ImportarProyectos()
            {
                int cont = 0;
            RepositorioUsuarios repoU = new RepositorioUsuarios();
                try
                {
                //id cedula titulo descr monto cuotas tasa valor cuota fecha pres ruta inameg 
                //tipo exp o cant int
                using (StreamReader sr = new StreamReader(Path.Combine(ruta, "proyectos.txt")))
                    {
                        string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        var lineaVec = linea.Split("|".ToCharArray());
                        string tipo = lineaVec[8].ToString();
                        int id = int.Parse(lineaVec[10]);
                        //if (repoProyectos.FindById(id) == null)
                        //{
                            if (tipo == "cooperativo")
                            {
                                Cooperativo c = new Cooperativo
                                {
                                    //id= int.Parse(lineaVec[0]),
                                    cedula = lineaVec[0].ToString(),
                                    titulo = lineaVec[1].ToString(),
                                    descripcion = lineaVec[2].ToString(),
                                    monto = decimal.Parse(lineaVec[3]),
                                    montoRestante = decimal.Parse(lineaVec[3]),
                                    cuotas = int.Parse(lineaVec[4]),
                                    tasaInteres = Decimal.Parse(lineaVec[5]),
                                    fechaPresentacion = DateTime.Parse(lineaVec[6]),
                                    rutaImagen = lineaVec[7].ToString(),
                                    cantIntegrantes = int.Parse(lineaVec[9]),
                                    id = int.Parse(lineaVec[10])
                                };
                                repoProyectos.Add(c);
                            }
                            else
                            {
                                Personal p = new Personal
                                {
                                    // id = int.Parse(lineaVec[0]),
                                    cedula = lineaVec[0].ToString(),
                                    titulo = lineaVec[1].ToString(),
                                    descripcion = lineaVec[2].ToString(),
                                    monto = decimal.Parse(lineaVec[3]),
                                    montoRestante = decimal.Parse(lineaVec[3]),
                                    cuotas = int.Parse(lineaVec[4]),
                                    tasaInteres = Decimal.Parse(lineaVec[5]),
                                    fechaPresentacion = DateTime.Parse(lineaVec[6]),
                                    rutaImagen = lineaVec[7].ToString(),
                                    experiencia = lineaVec[9].ToString(),
                                    id = int.Parse(lineaVec[10])
                                };
                                repoProyectos.Add(p);
                            }
                            linea = sr.ReadLine();
                        }
                        //linea = sr.ReadLine();
                    }
                   // }
                    return cont;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        public int ImportarSolicitantes()
            {
                RepositorioUsuarios repoUsuarios = new RepositorioUsuarios();
                int cont = 0;
                StreamReader sr = new StreamReader(Path.Combine(ruta, "solicitantes.txt"));
                string linea = sr.ReadLine();
                while (linea != null)
                {

                    var lineaVec = linea.Split("|".ToCharArray());
                    Solicitante solicitante = new Solicitante
                    {
                        cedula = lineaVec[0].ToString(),
                        nombre = lineaVec[1].ToString(),
                        apellido = lineaVec[2].ToString(),
                        fechaNacimiento = DateTime.Parse(lineaVec[3]),
                        email= lineaVec[4].ToString(),
                        celular= lineaVec[5].ToString(),
                        password= lineaVec[1].Substring(0,1).ToLower()+ lineaVec[2].Substring(0,1).ToUpper()+ lineaVec[0].ToString(),
                    };
                repoUsuarios.Add(solicitante);                  
                    linea = sr.ReadLine();
                }
             return cont;
            }

        }
    }

