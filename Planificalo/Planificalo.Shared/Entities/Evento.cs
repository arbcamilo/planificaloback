using System;
using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public string Lugar { get; set; }
        public int TipoEventoId { get; set; }

        public string? Imagen { get; set; }

        // Relaci�n con Cotizacion
        public List<Cotizacion> Cotizaciones { get; set; }
    }
}