using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using System;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class DashboardDAO : IDashboardDAO
    {
        private readonly MigrationDbContext _context;

        public DashboardDAO(MigrationDbContext context)
        {
            _context = context;
        }

        public DashboardDTO GraficaGenero(int mes)
        {
            try
            {
                DashboardDTO dto = new DashboardDTO();
                dto.labels = new string[] { "Hombres", "Mujeres"};
                var dataTemp = new int[2];
                dataTemp[0] = _context.Citas.Where(c => c.Start.Month == mes && c.Usuario.sexo == Char.ToString('M') && c.Status=="Confirmada").Include(u => u.Usuario).Count();
                dataTemp[1] = _context.Citas.Where(c => c.Start.Month == mes && c.Usuario.sexo == Char.ToString('F') && c.Status == "Confirmada").Include(u => u.Usuario).Count();
                dto.data = dataTemp;
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardDTO GraficaDepartamentoPorCitas(int mes)
        {
            try
            {
                DashboardDTO dto = new DashboardDTO();
                var labels = new List<string>();
                var data = new List<int>();

                var guids = _context.Departamentos.ToArray();

                for (int i = 0; i < guids.Length; i++)
                {
                    labels.Add(guids[i].nombre);
                    data.Add(_context.Citas.Where(d => d.Empleado.Departamento.id == guids[i].id && d.Status=="Confirmada" && d.Start.Month == mes).Include(e => e.Empleado.Departamento).Count());
                };

                dto.labels = labels.ToArray();
                dto.data = data.ToArray();
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardDTO GraficaTopDoctores(int mes)
        {
            try
            {
                DashboardDTO dto = new DashboardDTO();
                var labels = new List<string>();
                var data = new List<int>();

                var empleados = _context.Citas.Where(c => c.Status == "Confirmada" && c.Start.Month == mes)
                            .Include(i => i.Empleado)
                            .GroupBy(info => info.Empleado.username)
                            .Select(group => new
                            {
                                Empleado = group.First().DoctorName,
                                Count = group.Count()
                            }).OrderByDescending(o => o.Count).Take(5).ToList();


                for (int i = 0; i < empleados.Count(); i++)
                {
                    labels.Add(empleados[i].Empleado);
                    data.Add(empleados[i].Count);
                };

                dto.labels = labels.ToArray();
                dto.data = data.ToArray();
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardDTO GraficaPacientesRangoEdad()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO();
                dto.labels = new string[6];
                dto.data = new int[6];

                dto.labels[0]=("Primera Infancia (0-5 años)");
                dto.data[0]=(_context.Usuario.ToList().Where(u => u.edad >= 0 && u.edad <= 5).Count());

                dto.labels[1]=("Infancia (6 - 11 años)");
                dto.data[1]=(_context.Usuario.ToList().Where(u => u.edad >= 6 && u.edad <= 11).Count());

                dto.labels[2] = ("Adolescencia (12 - 18 años)");
                dto.data[2] = (_context.Usuario.ToList().Where(u => u.edad >= 12 && u.edad <= 18).Count());

                dto.labels[3] = ("Juventud (14 - 26 años)");
                dto.data[3] = (_context.Usuario.ToList().Where(u => u.edad >= 14 && u.edad <= 26).Count());

                dto.labels[4] = ("Adultez (27- 59 años)");
                dto.data[4] = (_context.Usuario.ToList().Where(u => u.edad >= 27 && u.edad <= 59).Count());

                dto.labels[5] = ("Vejez (60 años o mas)");
                dto.data[5] = (_context.Usuario.ToList().Where(u => u.edad >= 60).Count());

                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardNumberDTO CantidadCitasPendientes(int mes)
        {
            try
            {
                DashboardNumberDTO dto = new DashboardNumberDTO();
                dto.data = _context.Citas.Where(c => c.Start.Month == mes && c.Status== "En espera").Count();

                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardNumberDTO CantidadCitasConfirmadas(int mes)
        {
            try
            {
                DashboardNumberDTO dto = new DashboardNumberDTO();
                dto.data = _context.Citas.Where(c => c.Start.Month == mes && c.Status == "Confirmada").Count();

                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardNumberDTO CantidadPacientes()
        {
            try
            {
                DashboardNumberDTO dto = new DashboardNumberDTO();
                dto.data = _context.Usuario.Count();

                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DashboardNumberDTO CantidadDoctores()
        {
            try
            {
                DashboardNumberDTO dto = new DashboardNumberDTO();
                dto.data = _context.Empleados.Where(d=> d.rol=="Doctor").Count();

                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

    }
}
