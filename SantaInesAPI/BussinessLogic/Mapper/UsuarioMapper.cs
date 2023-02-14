﻿using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class UsuarioMapper
    {
        public static UsuarioDTO EntityToDTO(Usuario u)
        {
            return new UsuarioDTO()
            {
                username = u.username,
                password = u.password,
                cedula = u.cedula,
                nombre_completo = u.nombre_completo,
                apellido_completo = u.apellido_completo,
                fecha_Nacimiento = u.fecha_nacimiento,
                sexo = u.sexo,
                telefono = u.telefono,
                email = u.email,
                id_direccion = u.id_direccion,
                edad = u.edad,
                idHistoria = u.idHistoria
            };
        }

        public static Usuario DtoToEntity(UsuarioDTO u)
        {
            return new Usuario()
            {
                username = u.username,
                password = u.password,
                cedula = u.cedula,
                nombre_completo = u.nombre_completo,
                apellido_completo = u.apellido_completo,
                fecha_nacimiento = u.fecha_Nacimiento,
                sexo = u.sexo,
                telefono = u.telefono,
                email = u.email,
                id_direccion = u.id_direccion,
                idHistoria = u.idHistoria
            };
        }

    }
}
