using ProyectoAsistencia.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoAsistencia.Data
{
    public class DataBaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DataBaseContext(string path) 
        { 
            Connection = new SQLiteAsyncConnection(path);

            Connection.CreateTableAsync<Empresa>().Wait();            
            Connection.CreateTableAsync<Locacion>().Wait();
            Connection.CreateTableAsync<TipoUsuario>().Wait();
            Connection.CreateTableAsync<TipoDocumento>().Wait();
            Connection.CreateTableAsync<RangosNumericosTarjetero>().Wait();
            Connection.CreateTableAsync<Tarjetero>().Wait();
            Connection.CreateTableAsync<Usuario>().Wait();
            Connection.CreateTableAsync<Asistencia>().Wait();
            Connection.CreateTableAsync<Hora>().Wait();
            Connection.CreateTableAsync<ModoEmergencia>().Wait();
        }

        // ----------------------------------------InsertItems-----------------------------------------

        // USUARIO
        public async Task<int> InsertUsuarioAsyn(Usuario item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<int> RegistrarUsuario(Usuario usuario)
        {
            // Inserta un nuevo registro en la tabla Usuario
            return await Connection.ExecuteAsync(
                "INSERT INTO Usuario (IdentificacionUsuario, TipoDocumentoUsuario, NombreUsuario, GeneroUsuario, CargoUsuario, CelularUsuario, CorreoUsuario, EstadoEmpleado, EPSEmpleado, ARLEmpleado, TipoSangreUsuario, NumeroContactoEmergencia, NombreContactoEmergencia, TipoUsuario, NumeroTarjetero, Pass, Empresa, Locacion) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)",
                usuario.IdentificacionUsuario, usuario.TipoDocumentoUsuario, usuario.NombreUsuario, usuario.GeneroUsuario, usuario.CargoUsuario, usuario.CelularUsuario, usuario.CorreoUsuario, "Activo", usuario.EPSEmpleado, usuario.ARLEmpleado, usuario.TipoSangreUsuario, usuario.NumeroContactoEmergencia, usuario.NombreContactoEmergencia, usuario.TipoUsuario, usuario.NumeroTarjetero, usuario.IdentificacionUsuario, "", "");
        }

        // EMPRESA

        public async Task<int> InsertItemAsyn(Empresa item)
        {
            return await Connection.InsertAsync(item);
        }   
        

        // LOCACION

        public async Task<int> InsertItemAsynLocacion(Locacion item)
        {
            return await Connection.InsertAsync(item);
        }


        // TIPO USUARIO

        public async Task<int> RegistrarTipoUsuario(TipoUsuario tipoUsuario)
        {
            // Inserta un nuevo registro en la tabla TipoUsuario
            return await Connection.ExecuteAsync(
                "INSERT INTO TipoUsuario (_TipoUsuario, EstadoTipoUsuario) VALUES (?, ?)",
                tipoUsuario._TipoUsuario, tipoUsuario.EstadoTipoUsuario);
        }              

        public async void RegistrarTiposUsuarioPorDefecto()
        {
            try
            {
                // Lista de consultas predefinidas
                var consultasInsert = new List<string>
                {
                    "INSERT INTO TipoUsuario (_TipoUsuario, EstadoTipoUsuario) VALUES ('Administrador', 'Disponible')",
                    "INSERT INTO TipoUsuario (_TipoUsuario, EstadoTipoUsuario) VALUES ('AdministradorPrincipal', 'Disponible')",
                    "INSERT INTO TipoUsuario (_TipoUsuario, EstadoTipoUsuario) VALUES ('Desarrollador', 'Disponible')",
                    "INSERT INTO TipoUsuario (_TipoUsuario, EstadoTipoUsuario) VALUES ('Empleado', 'Disponible')",
                    "INSERT INTO TipoUsuario (_TipoUsuario, EstadoTipoUsuario) VALUES ('Visitante', 'Disponible')"
                };

                // Ejecutar cada consulta
                foreach (var consulta in consultasInsert)
                {
                    await Connection.ExecuteAsync(consulta);
                }

                Console.WriteLine("Los tipos de usuario por defecto se han registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar los tipos de usuario: {ex.Message}");
            }
        }


        // TIPO DOCUMENTO

        public async void RegistrarTiposDocumentoPorDefecto()
        {
            try
            {
                // Lista de consultas predefinidas
                var consultasInsert = new List<string>
                {
                    "INSERT INTO TipoDocumento (_tipoDocumento, EstadoTipoDocumento) VALUES ('Cedula de ciudadania', 'Disponible')",
                    "INSERT INTO TipoDocumento (_tipoDocumento, EstadoTipoDocumento) VALUES ('Pasaporte', 'Disponible')",
                    "INSERT INTO TipoDocumento (_tipoDocumento, EstadoTipoDocumento) VALUES ('Cedula de extranjeria', 'Disponible')"
                };

                // Ejecutar cada consulta
                foreach (var consulta in consultasInsert)
                {
                    await Connection.ExecuteAsync(consulta);
                }

                Console.WriteLine("Los tipos de documento de usuario por defecto se han registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar los tipos de documentos de usuario: {ex.Message}");
            }
        }


        // RANGOS TARJETERO

        public async void RegistrarRangosTarjetero()
        {
            try
            {
                // Lista de consultas predefinidas
                var consultasInsert = new List<string>
                {
                    "INSERT INTO RangosNumericosTarjetero (TipoRangoTarjetero, RangoSuperior, RangoInferior, EstadoRango) VALUES ('Empleados', 300, 1, 'Disponible')",
                    "INSERT INTO RangosNumericosTarjetero (TipoRangoTarjetero, RangoSuperior, RangoInferior, EstadoRango) VALUES ('Visitantes', 500, 301, 'Disponible')"
                };

                // Ejecutar cada consulta
                foreach (var consulta in consultasInsert)
                {
                    await Connection.ExecuteAsync(consulta);
                }

                Console.WriteLine("Los Rangos para el tarjetero por defecto se han registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar los tipos de rangos: {ex.Message}");
            }
        }


        // TARJETERO

        public async Task<int> RegistrarNumeroTarjetero(Tarjetero tarjetero)
        {
            // Inserta un nuevo registro en la tabla TipoUsuario
            return await Connection.ExecuteAsync(
                "INSERT INTO Tarjetero (NumeroEnTarjetero, EstadoNumero, RangoPertenencia, EmpresaAsociada, LocacionAsociada) VALUES (?, ?, ?, ?, ?)",
                tarjetero.NumeroEnTarjetero, tarjetero.EstadoNumero, tarjetero.RangoPertenencia, tarjetero.EmpresaAsociada, tarjetero.LocacionAsociada);
        }


        // ASISTENCIA
        public async Task<int> InsertAsistenciaDefault(Asistencia item)
        {
            return await ExisteAsistenciaAsync(item.FechaAsistencia) == false
                ? await Connection.ExecuteAsync(
                "INSERT INTO Asistencia (FechaSincronizacion, FechaAsistencia, EstadoAsistencia) VALUES (?, ?, ?)",
                "No sincronizado", item.FechaAsistencia, "Valido")
                :0;
        }

        public async Task<int> InsertAsistenciaSincronizado(Asistencia item)
        {
            return await Connection.ExecuteAsync(
                "INSERT INTO Asistencia (FechaSincronizacion, FechaAsistencia, EstadoAsistencia) VALUES (?, ?, ?)",
                item.FechaSincronizacion, item.FechaAsistencia, item.EstadoAsistencia);
        }


        // HORA

        public async Task<int> InsertHoraDefault(Hora item)
        {
            List<Hora> horarios = await GetHorariosUsuario(item.UsuarioRelacionado);

            if (horarios.Count != 0)
            {
                return item.EstadoHora == "Ausente" && horarios[horarios.Count - 1].EstadoHora != "Presente"
                          ? await Connection.ExecuteAsync(
                            "INSERT INTO Hora (HoraLlegada, HoraSalida, EstadoHora, AsistenciaRelacionada, UsuarioRelacionado) VALUES (?, ?, ?, ?, ?)",
                            item.HoraLlegada, "Pendiente", "Presente", item.AsistenciaRelacionada, item.UsuarioRelacionado)
                          : item.EstadoHora == "Presente" && horarios[horarios.Count - 1].EstadoHora != "Ausente"
                          ? await Connection.ExecuteAsync(
                            "INSERT INTO Hora (HoraLlegada, HoraSalida, EstadoHora, AsistenciaRelacionada, UsuarioRelacionado) VALUES (?, ?, ?, ?, ?)",
                            item.HoraLlegada, item.HoraSalida, "Ausente", item.AsistenciaRelacionada, item.UsuarioRelacionado)
                          : 0;
            }
            else
            {
                return item.EstadoHora == "Ausente"
                          ? await Connection.ExecuteAsync(
                            "INSERT INTO Hora (HoraLlegada, HoraSalida, EstadoHora, AsistenciaRelacionada, UsuarioRelacionado) VALUES (?, ?, ?, ?, ?)",
                            item.HoraLlegada, "Pendiente", "Presente", item.AsistenciaRelacionada, item.UsuarioRelacionado)
                          : item.EstadoHora == "Presente"
                          ? await Connection.ExecuteAsync(
                            "INSERT INTO Hora (HoraLlegada, HoraSalida, EstadoHora, AsistenciaRelacionada, UsuarioRelacionado) VALUES (?, ?, ?, ?, ?)",
                            item.HoraLlegada, item.HoraSalida, "Ausente", item.AsistenciaRelacionada, item.UsuarioRelacionado)
                          : 0;
            }            
        }

        public async Task<int> InsertHoraSincronizado(Hora item)
        {
            return await ExisteHoraAsync(item) == true
                          ? 0
                          : await InsertHoraDefault(item);
        }

        public async Task<int> InsertHoraModoEmergencia(ModoEmergencia item)
        {
            List<ModoEmergencia> horarios = await GetHorariosModoEmegencia(item.UsuarioRelacionado);

            int retorno;

            try
            {

                retorno = item.EstadoHoraReporte == "Presente"
                           ? await Connection.ExecuteAsync(
                             "INSERT INTO ModoEmergencia (HoraReporte, EstadoHoraReporte, AsistenciaRelacionada, UsuarioRelacionado, NumeroTarjeteroReporte) VALUES (?, ?, ?, ?, ?)",
                             item.HoraReporte, "A salvo", item.AsistenciaRelacionada, item.UsuarioRelacionado, item.NumeroTarjeteroReporte)
                           : item.EstadoHoraReporte == "Ausente"
                           ? await Connection.ExecuteAsync(
                             "INSERT INTO ModoEmergencia (HoraReporte, EstadoHoraReporte, AsistenciaRelacionada, UsuarioRelacionado, NumeroTarjeteroReporte) VALUES (?, ?, ?, ?, ?)",
                             item.HoraReporte, "Ausente", item.AsistenciaRelacionada, item.UsuarioRelacionado, item.NumeroTarjeteroReporte)
                           : item.EstadoHoraReporte == "No se presento"
                           ? await Connection.ExecuteAsync(
                             "INSERT INTO ModoEmergencia (HoraReporte, EstadoHoraReporte, AsistenciaRelacionada, UsuarioRelacionado, NumeroTarjeteroReporte) VALUES (?, ?, ?, ?, ?)",
                             item.HoraReporte, "No se presento", item.AsistenciaRelacionada, item.UsuarioRelacionado, item.NumeroTarjeteroReporte)
                           : 0;

               

                return retorno;
                
            }
            catch (Exception ex)
            {
                retorno = 0;

                Console.WriteLine($"Error al registrar asistencias de la emergencia: {ex.Message}");
                
            }
            
            return retorno;
        }

        // ----------------------------------------GetItems-----------------------------------------

        // Empresa
        public async Task<List<Empresa>> GetItemsAsync()
        {
            //Retorna todo
            return await Connection.Table<Empresa>().ToListAsync();

        }
        
        public async Task<List<Empresa>> GetEmpresasActivas()
        {          
            // Filtra las empresas donde el estado es "Activo"
            return await Connection.Table<Empresa>()
                                   .Where(e => e.EstadoEmpresa == "Activo")
                                   .ToListAsync();
        }

        public async Task<Empresa> GetEmpresaNumeroTarjetero(string empresa)
        {
            // Filtra la primera empresa activa encontrada
            return await Connection.Table<Empresa>()
                                   .Where(e => e.NombreEmpresa == empresa)
                                   .FirstOrDefaultAsync();
        }

        public async Task<List<Empresa>> GetEmpresaBuscada(string Referencia)
        {
            // Filtra la locacion que coincide con la referencia
            return await Connection.Table<Empresa>()
                                   .Where(e => e.NombreEmpresa == Referencia)
                                   .ToListAsync();
        }

        // Locaciones

        public async Task<List<Locacion>> GetItemsAsyncLocacion()
        {
            return await Connection.Table<Locacion>().ToListAsync();
        }

        public async Task<List<Locacion>> GetLocacionesActivas()
        {
            // Filtra las Locaciones donde el estado es "Activo"
            return await Connection.Table<Locacion>()
                                   .Where(e => e.EstadoLocacion == "Activa")
                                   .ToListAsync();
        }

        public async Task<Locacion> GetLocacionNumeroTarjetero(string locacion)
        {
            // Filtra la primera empresa activa encontrada
            return await Connection.Table<Locacion>()
                                   .Where(e => e.NombreLocacion == locacion)
                                   .FirstOrDefaultAsync();
        }

        public async Task<List<Locacion>> GetLocacionBuscada(string Referencia)
        {
            // Filtra la locacion que coincide con la referencia
            return await Connection.Table<Locacion>()
                                   .Where(e => e.NombreLocacion == Referencia)
                                   .ToListAsync();
        }


        // Rangos de numeros 

        public async Task<List<RangosNumericosTarjetero>> GetRangoTarjeteroAsync()
        {
            //Retorna todo
            return await Connection.Table<RangosNumericosTarjetero>().ToListAsync();

        }

        public async Task<int> GetValorSuperiorRangoTarjetero(string tipoRango)
        {
            var resultado = await Connection.Table<RangosNumericosTarjetero>()
                                             .Where(e => e.TipoRangoTarjetero == tipoRango)
                                             .FirstOrDefaultAsync();

            return resultado?.RangoSuperior ?? 0; // Devuelve 0 si no hay resultados
        }
        
        public async Task<int> GetValorInferiorRangoTarjetero(string tipoRango)
        {
            var resultado = await Connection.Table<RangosNumericosTarjetero>()
                                             .Where(e => e.TipoRangoTarjetero == tipoRango)
                                             .FirstOrDefaultAsync();

            return resultado?.RangoInferior ?? 0; // Devuelve 0 si no hay resultados
        }


        // Tipo documento

        public async Task<List<TipoDocumento>> GetTipoDocumentoAsync()
        {
            //Retorna todo
            return await Connection.Table<TipoDocumento>().ToListAsync();

        }


        // Tipo Usuario

        public async Task<List<TipoUsuario>> GetTipoUsuarioAsync()
        {
            //Retorna todo
            return await Connection.Table<TipoUsuario>().ToListAsync();

        }


        // Tarjetero

        public async Task<List<Tarjetero>> GetNumerosTarjeteroAsync()
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>().ToListAsync();

        }

        public async Task<List<Tarjetero>> GetNumerosTarjeteroDisponiblesAsync()
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.EstadoNumero == "Disponible")
                                   .ToListAsync();

        }

        // Retorna todos los numeros de tarjetero asociados a algun usuario
        public async Task<List<Tarjetero>> GetNumerosTarjeteroNoDisponiblesAsync()
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.EstadoNumero != "Disponible")
                                   .ToListAsync();

        }

        // Retorna todos los numeros de tarjetero asociados a algun usuario por empresa
        public async Task<List<Tarjetero>> GetNumerosTarjeteroNoDisponiblesXEmpresaAsync(string empresaRef)
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.EstadoNumero != "Disponible" && e.EmpresaAsociada == empresaRef)
                                   .ToListAsync();
        }

        // Retorna todos los numeros de tarjetero asociados a algun usuario por empresa
        public async Task<List<Tarjetero>> GetNumerosTarjeteroNoDisponiblesXEmpresaLocacionAsync(string empresaRef, string locacionRef)
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.EstadoNumero != "Disponible" && e.EmpresaAsociada == empresaRef && e.LocacionAsociada == locacionRef)
                                   .ToListAsync();
        }

        // Retorna la informacion del numero de tarjetero buscando por un valor 
        public async Task<List<Tarjetero>> GetUsuarioBuscadoIndividual(string usuarioRef)
        {
            Usuario usuario = await GetUsuarioIndividual(usuarioRef);

            // Filtra el tarjetero del usuario buscado
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.NumeroEnTarjetero == Int32.Parse(usuario.NumeroTarjetero))
                                   .ToListAsync();
        }

        // Retorna los numeros de tarjetero disponibles para los tipos de usuario empleado
        public async Task<List<Tarjetero>> GetNumerosTarjeteroEmpleadosAsync()
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.EstadoNumero == "Disponible" && e.RangoPertenencia == "Empleados")
                                   .ToListAsync();

        }

        // Retorna los numeros de tarjetero disponibles para los tipos de usuario visitante
        public async Task<List<Tarjetero>> GetNumerosTarjeteroVisitantesAsync()
        {
            //Retorna todo
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.EstadoNumero == "Disponible" && e.RangoPertenencia == "Visitantes")
                                   .ToListAsync();

        }

        // Retorina la informacion del numero de tarjetero buscando por un valor 
        public async Task<Tarjetero> GetNombreInfoNumeroTarjetero(int numero)
        {
            // Filtra la primera empresa activa encontrada
            return await Connection.Table<Tarjetero>()
                                   .Where(e => e.NumeroEnTarjetero == numero)
                                   .FirstOrDefaultAsync();
        }


        // USUARIO

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            //Retorna todo
            return await Connection.Table<Usuario>()
                                   .Where(e => e.TipoUsuario != "Administrador" && e.TipoUsuario != "AdministradorPrincipal" && e.TipoUsuario != "Desarrollador")
                                   .ToListAsync();

        }

        public async Task<List<Usuario>> GetUsuariosTodosAsync()
        {
            //Retorna todo
            return await Connection.Table<Usuario>()
                                   .Where(e => e.TipoUsuario != "Desarrollador")
                                   .ToListAsync();

        }

        public async Task<List<Usuario>> GetUsuarioBuscado(string numReferencia)
        {
            // Filtra el usuario que coincide con la referencia
            return await Connection.Table<Usuario>()
                                   .Where(e => e.IdentificacionUsuario == numReferencia || e.NumeroTarjetero == numReferencia || e.NombreUsuario == numReferencia)
                                   .ToListAsync();
        }

        //public async Task<Usuario> GetUsuarioIndividual(string numReferencia)
        //{
        //    Usuario user = await Connection.Table<Usuario>()
        //                           .Where(e => e.IdentificacionUsuario == numReferencia || e.NumeroTarjetero == numReferencia || e.NombreUsuario == numReferencia)
        //                           .FirstOrDefaultAsync();
        //    // Filtra el usuario que coincide con la referencia
        //    return user;
        //}

        public async Task<Usuario> GetUsuarioIndividual(string numReferencia)
        {
            try
            {
                return await Connection.Table<Usuario>()
                                   .Where(e => e.IdentificacionUsuario == numReferencia ||
                                               e.NumeroTarjetero == numReferencia ||
                                               e.NombreUsuario == numReferencia)
                                   .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario: {ex.Message}");
                return null;
            }
        }


        public async Task<List<Usuario>> GetUsuariosActivos()
        {
            // Filtra los usuarios donde el estado es "Activo"
            return await Connection.Table<Usuario>()
                                   .Where(e => e.EstadoEmpleado == "Activo" && e.TipoUsuario != "Desarrollador")
                                   .ToListAsync();
        }

        public async Task<List<Usuario>> GetUsuariosAdminActivos()
        {
            // Filtra los usuarios de tipo administrador y administrador principal
            return await Connection.Table<Usuario>()
                                   .Where(e => e.TipoUsuario == "Administrador" || e.TipoUsuario == "AdministradorPrincipal")
                                   .ToListAsync();
        }

        public async Task<List<Usuario>> GetUsuariosAdminPrincipalActivos()
        {
            // Filtra los usuarios de tipo administrador y administrador principal
            return await Connection.Table<Usuario>()
                                   .Where(e => e.TipoUsuario == "AdministradorPrincipal")
                                   .ToListAsync();
        }

        // ASISTENCIA

        public async Task<List<Asistencia>> GetAsistenciasTodas()
        {
            // Filtra el usuario que coincide con la referencia
            return await Connection.Table<Asistencia>()
                                   .ToListAsync();
        }

        public async Task<List<Asistencia>> GetAsistenciaBuscada(string FechaAsistenciaRef)
        {
            // Filtra el usuario que coincide con la referencia
            return await Connection.Table<Asistencia>()
                                   .Where(e => e.FechaAsistencia == FechaAsistenciaRef)
                                   .ToListAsync();
        }

        public async Task<List<Hora>> GetHorariosTodos()
        {
            // Filtra el usuario que coincide con la referencia
            return await Connection.Table<Hora>()
                                   .ToListAsync();
        }

        public async Task<List<Hora>> GetHorarioBuscado(string usuarioReferencia, string FechaAsistencia)
        {
            // Filtra el usuario que coincide con la referencia
            return await Connection.Table<Hora>()
                                   .Where(e => e.UsuarioRelacionado == usuarioReferencia && e.AsistenciaRelacionada == FechaAsistencia)
                                   .ToListAsync();
        }

        public async Task<List<Hora>> GetHorariosUsuario(string usuarioReferencia)
        {           
            try
            {
                // Filtra el usuario que coincide con la referencia
                return await Connection.Table<Hora>()
                                       .Where(e => e.UsuarioRelacionado == usuarioReferencia)
                                       .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el horarios del usuario: {ex.Message}");
                return null;
            }
        }

        public async Task<Hora> GetUltimoHorariosUsuario(string usuarioReferencia)
        {
            try
            {
                // Filtra el usuario y toma el último horario basado en el orden inverso
                return await Connection.Table<Hora>()
                       .Where(e => e.UsuarioRelacionado == usuarioReferencia)
                       .OrderByDescending(e => e.IdHora) // Orden inverso para obtener el último
                       .FirstOrDefaultAsync(); // Toma el primero en el nuevo orden
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el horario del usuario: {ex.Message}");
                return null;
            }
        }

        // Metodo que retorna el ultimo registro de la tabla de asistencia relacionada al usuario
        public async Task<Asistencia> GetAsistenciaActualUsuario(string ReferenciaUsuario)
        {
            // Obtener asistencias
            var asistenciasUsuario = await GetHorariosUsuario(ReferenciaUsuario);

            // Obtener la ultima hora de asistencia registrada
            Hora asistenciaHora = asistenciasUsuario.FirstOrDefault();

            // Obtiener la asistencia desde la tabla hora
            var asistenciaUsuario = await GetAsistenciaBuscada(asistenciaHora.AsistenciaRelacionada);

            Asistencia asistencia = asistenciaUsuario.FirstOrDefault();

            // Filtra los usuarios de tipo administrador y administrador principal
            return asistencia;
        }


        // MODO EMERGENCIA

        public async Task<List<ModoEmergencia>> GetHorariosModoEmegencia(string usuarioReferencia)
        {
            try
            {
                // Filtra el usuario que coincide con la referencia
                return await Connection.Table<ModoEmergencia>()
                                       .Where(e => e.UsuarioRelacionado == usuarioReferencia)
                                       .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el horarios del usuario: {ex.Message}");
                return null;
            }
        }

        public async Task<ModoEmergencia> GetUltimoHorarioModoEmergencia(string usuarioReferencia)
        {
            try
            {
                // Filtra el usuario y toma el último horario basado en el orden inverso
                return await Connection.Table<ModoEmergencia>()
                       .Where(e => e.UsuarioRelacionado == usuarioReferencia)
                       .OrderByDescending(e => e.IdHoraModoEmergencia) // Orden inverso para obtener el último
                       .FirstOrDefaultAsync(); // Toma el primero en el nuevo orden
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el horario del usuario: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ModoEmergencia>> GetHorariosEmergenciaTodos()
        {
            // Filtra el usuario que coincide con la referencia
            return await Connection.Table<ModoEmergencia>()
                                   .ToListAsync();
        }

        // ----------------------------------------DeleteItems-----------------------------------------

        public async void DeleteItemsArranque()
        {

            try
            {
                // Lista de consultas predefinidas
                var consultasInsert = new List<string>
                {
                    "DELETE FROM TipoUsuario",
                    "DELETE FROM TipoDocumento",
                    "DELETE FROM RangosNumericosTarjetero",
                    "DELETE FROM Tarjetero",
                    "DELETE FROM Usuario",
                    "DELETE FROM Asistencia",
                    "DELETE FROM Hora",
                };


                // Ejecutar cada consulta
                foreach (var consulta in consultasInsert)
                {
                    await Connection.ExecuteAsync(consulta);
                }

                Console.WriteLine("Se a receteado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recetear: {ex.Message}");
            }

        }
        
        public async Task<int> DeleteItemAsync(Empresa Item)
        {
            //Elimina el objeto completamente
            return await Connection.DeleteAsync(Item);

        }
        
        public async Task<int> InutilizarEmpresa(Empresa Item)
        {

            //Actualiza los estados para inutilizar empresas
            return await Connection.ExecuteAsync(
                    "UPDATE Empresa SET EstadoEmpresa = ? WHERE NombreEmpresa = ?",
                    "Inactiva", Item.NombreEmpresa);
        }

        public async Task<int> DeleteLocacionAsync(Locacion Item)
        {
            //Elimina el objeto completamente
            return await Connection.DeleteAsync(Item);

        }

        public async Task<int> InutilizarLocacion(Locacion Item)
        {
            //Actualiza los estados para inutilizar empresas
            return await Connection.ExecuteAsync(
                    "UPDATE Locacion SET EstadoLocacion = ? WHERE NombreLocacion = ?",
                    "Inactiva", Item.NombreLocacion);
        }

        public async Task<int> DeleteUsuarioAsync(Usuario Item)
        {
            //Elimina el objeto completamente
            return await Connection.DeleteAsync(Item);

        }

        public async Task<int> InutilizarUsuario(Usuario Item)
        {
            await UpdateDesTarjeteroLocacionAsync(Item.NumeroTarjetero, Item.Locacion);

            //Actualiza los estados para inutilizar usuario
            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET EstadoEmpleado = ? WHERE IdentificacionUsuario = ?",
                    "Inactivo", Item.IdentificacionUsuario);
        }

        public async void DeleteRegistrosEmergenciaAsync()
        {
            await Connection.ExecuteAsync("DELETE FROM ModoEmergencia");

        }

        // ----------------------------------------UpdateItems-----------------------------------------

        // Método para actualizar un objeto empresa en la base de datos
        public async Task<int> UpdateEmpresaAsync(Empresa empresa)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Empresa SET NombreEmpresa = ?, NITEmpresa = ?, LogoEmpresa = ?, EstadoEmpresa = ? WHERE NombreEmpresa = ?",
                    empresa.NombreEmpresa, empresa.NITEmpresa, empresa.LogoEmpresa, empresa.EstadoEmpresa, empresa.NombreEmpresa);


            //return await Connection.UpdateAsync(empresa);

        }

        // Método para actualizar un objeto locacion en la base de datos
        public async Task<int> UpdateLocacionAsync(Locacion locacion)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Locacion SET NombreLocacion = ?, RIG = ?, NombrePozo = ?, EstadoLocacion = ? WHERE NombreLocacion = ?",
                    locacion.NombreLocacion, locacion.RIG, locacion.NombrePozo, locacion.EstadoLocacion, locacion.NombreLocacion);


        }

        // Método para actualizar la asignacion de un tarjetero a un usuario
        public async Task<int> UpdateTarjeteroAsync(string empresa, string locacion, string valor)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Tarjetero SET EstadoNumero = ?, EmpresaAsociada = ?, LocacionAsociada = ? WHERE NumeroEnTarjetero = ?",
                    "Asignado", empresa, locacion, valor);

        }

        // Método para dejar libre nuevamente un numero del tarjetero
        public async Task<int> UpdateDesTarjeteroAsync(string valor)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Tarjetero SET EstadoNumero = ?, EmpresaAsociada = ?, LocacionAsociada = ? WHERE NumeroEnTarjetero = ?",
                    "Disponible", "Sin asignar", "Sin asignar", valor);

        }

        // Método para dejar libre nuevamente un numero del tarjetero cuando se elimina un usuario
        public async Task<int> UpdateDesTarjeteroLocacionAsync(string valor, string locacionRef)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Tarjetero SET EstadoNumero = ?, EmpresaAsociada = ?, LocacionAsociada = ? WHERE NumeroEnTarjetero = ? AND LocacionAsociada = ?",
                    "Disponible", "Sin asignar", "Sin asignar", valor, locacionRef);

        }

        // Método para actualizar un objeto persona en la base de datos
        public async Task<int> UpdateUsuarioParcialAsync(Usuario usuario)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET IdentificacionUsuario = ?, TipoDocumentoUsuario = ?, NombreUsuario = ?, GeneroUsuario = ?, CargoUsuario = ?, CelularUsuario = ?, CorreoUsuario = ?, EstadoEmpleado = ?, EPSEmpleado = ?, ARLEmpleado = ?, TipoSangreUsuario = ?, NumeroContactoEmergencia = ?, NombreContactoEmergencia = ?, TipoUsuario = ?, NumeroTarjetero = ?, Empresa = ?, Locacion = ? WHERE IdentificacionUsuario = ?",
                    usuario.IdentificacionUsuario, usuario.TipoDocumentoUsuario, usuario.NombreUsuario, usuario.GeneroUsuario, usuario.CargoUsuario, usuario.CelularUsuario, usuario.CorreoUsuario, usuario.EstadoEmpleado, usuario.EPSEmpleado, usuario.ARLEmpleado, usuario.TipoSangreUsuario, usuario.NumeroContactoEmergencia, usuario.NombreContactoEmergencia, usuario.TipoUsuario, usuario.NumeroTarjetero, usuario.Empresa, usuario.Locacion, usuario.IdentificacionUsuario);

        }

        // Método para actualizar el tipo de usuario como administrador 
        public async Task<int> UpdateUsuarioComoAdminAsync(string identificacion)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET TipoUsuario = ? WHERE IdentificacionUsuario = ? OR NombreUsuario = ?",
                    "Administrador", identificacion, identificacion);

        }

        // Método para actualizar el tipo de usuario como empleado 
        public async Task<int> UpdateDesUsuarioComoEmpleadoAsync(string identificacion)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET TipoUsuario = ? WHERE IdentificacionUsuario = ? OR NombreUsuario = ?",
                    "Empleado", identificacion, identificacion);

        }

        // Método para actualizar el tipo de usuario como administrador principal
        public async Task<int> UpdateUsuarioComoAdminOneAsync(string identificacion)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET TipoUsuario = ? WHERE IdentificacionUsuario = ? OR NombreUsuario = ?",
                    "AdministradorPrincipal", identificacion, identificacion);

        }

        // Método para actualizar contraseña de usuario admin
        public async Task<int> UpdatePassUserAdminAsync(string identificacion, string newpass)
        {
            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET Pass = ? WHERE IdentificacionUsuario = ?",
                    newpass, identificacion);

        }       

        // Método para quitar condicion de admin a un empleado
        public async Task<int> UpdateTipoUserDesAdminAsync(string identificacion, string numeroReferencia)
        {
            string tpUsuario = (Int32.Parse(numeroReferencia) > 300)
                            ? "Visitante"
                            : "Empleado";

            return await Connection.ExecuteAsync(
                    "UPDATE Usuario SET TipoUsuario = ? WHERE IdentificacionUsuario = ?",
                    tpUsuario, identificacion);

        }

        public async Task<int> UpdateAsistenciaSincronizada(string fechaRef, string fechaActualizacion)
        {
            //var ExisteAsistencia = await ExisteAsistenciaAsync(asistencia.FechaAsistencia);

            return await Connection.ExecuteAsync(
                    "UPDATE Asistencia SET FechaSincronizacion = ? WHERE IdentificacionUsuario = ?",
                    fechaActualizacion, fechaRef);

        }

        public async Task<int> UpdateHorarioUsuario(string fechaRef, string usuarioRef, string estadoRef)
        {
            //var ExisteAsistencia = await ExisteAsistenciaAsync(asistencia.FechaAsistencia);

            return await Connection.ExecuteAsync(
                    "UPDATE Hora SET EstadoHora = ? WHERE AsistenciaRelacionada = ? AND UsuarioRelacionado = ?",
                    estadoRef, fechaRef, usuarioRef);

        }

        // Método para actualizar la asistencia y el horario
        public async Task<int> UpdateAsistenciaHorarioAsync(Hora hora)
        {           

            return await ExisteAsistenciaAsync(hora.AsistenciaRelacionada) == true && hora.EstadoHora == "Ausente"
                                  ? await Connection.ExecuteAsync(
                                    "UPDATE Hora SET HoraLlegada = ?, EstadoHora = ? WHERE AsistenciaRelacionada = ? AND UsuarioRelacionado = ?",
                                    hora.HoraLlegada, hora.EstadoHora, hora.AsistenciaRelacionada, hora.UsuarioRelacionado)
                                  : hora.EstadoHora == "Presente"
                                  ? await Connection.ExecuteAsync(
                                    "UPDATE Hora SET HoraLlegada = ?, EstadoHora = ? WHERE AsistenciaRelacionada = ? AND UsuarioRelacionado = ?",
                                    hora.HoraLlegada, hora.HoraSalida, hora.EstadoHora, hora.AsistenciaRelacionada, hora.UsuarioRelacionado)
                                  : 0;

        }


        // ----------------------------------------Validacion si existe el rango de tarjetero para empleados-----------------------------------------
        public async Task<bool> ExisteTipoRangoEmpleadoAsync(string tpRangoTarjetero)
        {
            try
            {
                // Consulta en la base de datos para verificar si existe un registro con TipoRangoTarjetero = "Empleado"
                var resultado = await Connection.Table<RangosNumericosTarjetero>().FirstOrDefaultAsync(r => r.TipoRangoTarjetero == tpRangoTarjetero);

                // Si el resultado no es null, significa que existe al menos un registro
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

        public async Task<bool> ExisteUsuarioAsync(string identificacion, string pass)
        {
            try
            {
                // Consulta en la base de datos para verificar si existe un registro con la identiticacion y el pass del usuario
                var resultado = await Connection.Table<Usuario>().FirstOrDefaultAsync(r => (r.IdentificacionUsuario == identificacion || r.NombreUsuario == identificacion) && r.Pass == pass && (r.TipoUsuario == "Administrador" || r.TipoUsuario == "AdministradorPrincipal" || r.TipoUsuario == "Desarrollador"));

                // Si el resultado no es null, significa que existe al menos un registro
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

        public async Task<bool> ExisteUsuarioAdminPrincipalAsync(string identificacion, string pass)
        {
            try
            {
                // Consulta en la base de datos para verificar si existe un registro con la identiticacion y el pass del usuario
                var resultado = await Connection.Table<Usuario>().FirstOrDefaultAsync(r => r.IdentificacionUsuario == identificacion && r.Pass == pass && (r.TipoUsuario == "AdministradorPrincipal" || r.TipoUsuario == "Desarrollador"));

                // Si el resultado no es null, significa que existe al menos un registro
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

        public async Task<bool> ExisteUsuarioDevAsync(string identificacion, string pass)
        {
            try
            {
                // Consulta en la base de datos para verificar si existe un registro con la identiticacion y el pass del usuario
                var resultado = await Connection.Table<Usuario>().FirstOrDefaultAsync(r => r.IdentificacionUsuario == identificacion && r.Pass == pass && r.TipoUsuario == "Desarrollador");

                // Si el resultado no es null, significa que existe al menos un registro
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

        public async Task<bool> ExisteUsuarioAdminAsync(string identificacion, string pass)
        {
            try
            {
                // Consulta en la base de datos para verificar si existe un registro con la identiticacion y el pass del usuario
                var resultado = await Connection.Table<Usuario>().FirstOrDefaultAsync(r => r.IdentificacionUsuario == identificacion && r.Pass == pass && (r.TipoUsuario == "Administrador" || r.TipoUsuario == "Desarrollador"));

                // Si el resultado no es null, significa que existe al menos un registro
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

        public async Task<bool> ExisteAsistenciaAsync(string fechaAsistenciaRef)
        {
            try
            {
                // Consulta en la base de datos para verificar si existe un registro con TipoRangoTarjetero = "Empleado"
                var resultado = await Connection.Table<Asistencia>().FirstOrDefaultAsync(r => r.FechaAsistencia == fechaAsistenciaRef);

                // Si el resultado no es null, significa que existe al menos un registro
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

        public async Task<bool> ExisteHoraAsync(Hora hora)
        {
            try
            {
                bool retorno = false;
                // Consulta en la base de datos para verificar si existe un registro con TipoRangoTarjetero = "Empleado"
                var resultado = await Connection.Table<Hora>().FirstOrDefaultAsync(r => r.IdHora == hora.IdHora);

                if (resultado != null)
                {
                    if (resultado.HoraLlegada == hora.HoraLlegada && resultado.HoraSalida == hora.HoraSalida &&
                        resultado.AsistenciaRelacionada == hora.AsistenciaRelacionada && resultado.UsuarioRelacionado == hora.UsuarioRelacionado)
                    {
                        retorno = true;
                    }

                }

                // Si el resultado no es null, significa que existe al menos un registro
                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar la base de datos: {ex.Message}");
                return false; // Devuelve false en caso de error
            }
        }

    }
}
