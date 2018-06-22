using System.Configuration;
using System.Data.SqlClient;

namespace SistemaECAS
{

    public class Conexion
    {

        private System.Data.SqlClient.SqlCommand adoCmd;
        private System.Data.SqlClient.SqlConnection adoConn;
        private string conectionString;
        private System.Data.SqlClient.SqlDataReader dr;
        private int filas;
        private string sql;

        public System.Data.SqlClient.SqlDataReader Dr
        {
            get
            {
                return dr;
            }
            set
            {
                dr = value;
            }
        }

        public string Sql
        {
            get
            {
                return sql;
            }
            set
            {
                sql = value;
            }
        }

        public Conexion()
        {
            conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
            adoConn = new System.Data.SqlClient.SqlConnection(conectionString);
            adoConn.Open();
        }

        public void Cerrar()
        {
            this.adoConn.Close();
            this.adoConn = null;

        }

        public int ejecutar(string sql)
        {
            if (sql != null)
                this.sql = sql;
            adoCmd = new System.Data.SqlClient.SqlCommand(this.sql, adoConn);
            filas = adoCmd.ExecuteNonQuery();
            return filas;
        }

        public void leer(string sql)
        {
            if (sql != null)
            {
                this.sql = sql;
            }
            this.adoCmd = new SqlCommand(this.sql, this.adoConn);
            this.dr = this.adoCmd.ExecuteReader();

        }

        public bool registro()
        {
            if (dr.Read())
                return true;
            return false;
        }

    } // class Conexion

}

