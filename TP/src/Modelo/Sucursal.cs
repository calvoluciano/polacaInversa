﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    class Sucursal : Usuario
    {
        public decimal codigoPostal;

        public Sucursal(DataRow data)
        {
            New(data);
            habilitado = (Boolean)data["Sucursal_Habilitada"];
            codigoPostal = (decimal)data["Codigo_Postal"];
        }

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("Sucursal_UPDATE",
                                         "id_sucursal", id,
                                         "nombre", nombre,
                                         "codigoPostal", codigoPostal,
                                         "estado_sucursal", habilitado);
        }

        public static void nuevo(int id, decimal codigoPostal, Boolean habilitado)  // persisto una sucursal nueva
        {
            DB.correrProcedimiento("Sucursal_NUEVO",
                                         "id", id,
                                         "codigoPostal", codigoPostal,
                                         "habilitado", habilitado);
        }

        public static void inhabilitar(int id)                                      // inhabilito la sucursal
        {
            Usuario.inhabilitar("SUCURSAL", id);
        }
    }
}
