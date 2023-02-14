using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class HistoriaMedicaMapper
    {
        public static HistoriaMedicaDTO EntityToDTO(HistoriaMedica h)
        {
            return new HistoriaMedicaDTO()
            {
                idHistoria = h.idHistoria,
                altura = h.altura,
                peso = h.peso,
                tipoSangre = h.tipoSangre,
                alergias = h.alergias,
                andtFamiliares = h.andtFamiliares,
                antPeronales = h.antPeronales,
                patologia = h.patologia,
                intQuirurgica = h.intQuirurgica,
                tratHabitual = h.tratHabitual
            };
        }

        public static HistoriaMedica DtoToEntity(HistoriaMedicaDTO h)
        {
            return new HistoriaMedica()
            {
                idHistoria = h.idHistoria,
                altura = h.altura,
                peso = h.peso,
                tipoSangre = h.tipoSangre,
                alergias = h.alergias,
                andtFamiliares = h.andtFamiliares,
                antPeronales = h.antPeronales,
                patologia = h.patologia,
                intQuirurgica = h.intQuirurgica,
                tratHabitual = h.tratHabitual
            };
        }

    }
}
