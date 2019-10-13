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

        #region constructor

        public ClsContactoMgr(ClsContacto parObjContacto) {

            objContacto = parObjContacto;
        }

        #endregion
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

        public void GuardarDatos() {

            try
            {
                cnGeneral = new ClsDatos();
                SqlParameter[] parParameters = new SqlParameter[4];
                parParameters[0] = new SqlParameter();
                parParameters[0].ParameterName = "@opc";
                parParameters[0].SqlDbType = SqlDbType.Int;
                parParameters[0].SqlValue = objContacto.opc;

                parParameters[1] = new SqlParameter();
                parParameters[1].ParameterName = "@Id";
                parParameters[1].SqlDbType = SqlDbType.Int;
                parParameters[1].SqlValue = objContacto.Id;

                parParameters[2] = new SqlParameter();
                parParameters[2].ParameterName = "@Nombre";
                parParameters[2].SqlDbType = SqlDbType.VarChar;
                parParameters[2].Size = 50;
                parParameters[2].SqlValue = objContacto.Nombre;

                parParameters[3] = new SqlParameter();
                parParameters[3].ParameterName = "@Telefono";
                parParameters[3].SqlDbType = SqlDbType.VarChar;
                parParameters[3].Size = 20;
                parParameters[3].SqlValue = objContacto.Telefono;

                cnGeneral.EjecutarSP(parParameters, "SPContacto");

            }
            catch(Exception e) {

                throw new Exception(e.Message);
            }

        }

        public void EliminarDatos() {

            try {
                cnGeneral = new ClsDatos();

                SqlParameter[] parParameters = new SqlParameter[2];
                parParameters[0] = new SqlParameter();
                parParameters[0].ParameterName = "@opc";
                parParameters[0].SqlDbType = SqlDbType.Int;
                parParameters[0].SqlValue = objContacto.opc;

                parParameters[1] = new SqlParameter();
                parParameters[1].ParameterName = "@Id";
                parParameters[1].SqlDbType = SqlDbType.Int;
                parParameters[1].SqlValue = objContacto.Id;

                cnGeneral.EjecutarSP(parParameters, "SPContacto");

            } catch (Exception e) {
                throw new Exception(e.Message);
            }

        }
   }

}
