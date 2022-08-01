﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenQuarkCSharp.Models
{
    public enum TipoDeCuello
    {
        Mao,
        Comun
    }
    public enum TipoDeManga
    {
        Corta,
        Larga
    }
    public class Camisa : Prenda
    {
        public TipoDeCuello Cuello { get; set; }
        public TipoDeManga Manga { get; set; }
        public Camisa()
        {
            Cuello = TipoDeCuello.Comun;
            Manga = TipoDeManga.Larga;
        }
        public Camisa(string detalle, TipoDeCalidad calidad, float precioUnitario, int cantidad, TipoDeCuello cuello, TipoDeManga manga)
            :base(detalle,calidad,precioUnitario,cantidad)
        {
            Cuello = cuello;
            Manga = manga;
        }
        public override Cotizacion CalcularCotizacion()
        {
            Cotizacion cotizacion = new Cotizacion(this)
            {
                Monto = PrecioUnitario,
            };
            if (Manga == TipoDeManga.Corta)
            {
                float descuento = PrecioUnitario * (float)0.1;
                cotizacion.Monto -= descuento;
            }
            if (Cuello == TipoDeCuello.Mao)
            {
                float recargo = PrecioUnitario * (float)0.03;
                cotizacion.Monto += recargo;
            }
            return cotizacion;
        }
    }
}