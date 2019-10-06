using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
   public class ClsContactoMgr
    {
        ClsDatos cnGeneral = null;
        ClsContacto objContacto = null;
        DataTable tblDatos = null;

        public ClsContactoMgr(ClsContacto parObjContacto) {

            objContacto = parObjContacto;
        }

        public DataTable Listar() {
            tblDatos = new DataTable();

            try {
                cnGeneral = new ClsDatos();
                SqlParameter[] parParameters = new SqlParameter[1];
                parParameters[0] = new SqlParameter();
                parParameters[0].ParameterName = "@opc";
                parParameters[0].SqlDbType = SqlDbType.Int;
                parParameters[0].SqlValue = objContacto.opc;
                tblDatos = cnGeneral.RetornaTabla(parParameters,"SPContacto");

            }
            catch (Exception e) {
                throw new Exception(e.Message);
                
            }
            return tblDatos;

        }
    }
}
