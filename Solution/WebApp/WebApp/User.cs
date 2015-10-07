using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Classes
{
    public class User
    {
        #region Attributes

        private string id;
        private string name;
        private string email;
        private string password;

        #endregion

        #region Properties

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string EMail
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        #region Methods
        public virtual void Load(DataRow row)
        {
            Id = Convert.ToString(row["UserId"]);
            Name = Convert.ToString(row["Name"]);
            Password = Convert.ToString(row["Password"]);
            EMail = Convert.ToString(row["Email"]);
        }

        public static User getUsuarioByLogin(string email, string password)
        {
            DataTable dt = DB.getStaticData("SELECT * FROM [User] WHERE Email = "
                + DB.Quote(email) + " AND Password = " + DB.Quote(DB.getMD5Hash(password)));
            User usuario = new User();
            if (dt.Rows.Count > 0)
            {
                usuario.Load(dt.Rows[0]);
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public static User getUsuario(int userId)
        {
            User usuario = new User();
            DataTable table = DB.getStaticData("SELECT * FROM Usuario WHERE ID = " + userId);
            if (table.Rows.Count > 0)
                usuario.Load(table.Rows[0]);
            return usuario;
        }

        public static List<User> getUsuarios()
        {
            List<User> usuarios = new List<User>();
            DataTable table = DB.getStaticData(" SELECT * FROM Usuario ");
            foreach (DataRow row in table.Rows)
            {
                User usuario = new User();
                usuario.Load(row);
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        private int GetLastID()
        {
            return Convert.ToInt32(DB.getValue(" SELECT TOP 1 ID FROM Usuario ORDER BY ID DESC "));
        }

        //public virtual void Post()
        //{
        //    string sql = "";
        //    SqlParameter[] paramsPost;
        //    switch (RecordState)
        //    {
        //        case RecordState.Insert:
        //            sql = " INSERT INTO Usuario (Nome, Sobrenome, Username, Senha, Tipo) " +
        //                " VALUES (@Nome, @Sobrenome, @Username, @Senha, @Tipo) ";
        //            paramsPost = new SqlParameter[] {
        //                DB.MakeParam("@Nome", SqlDbType.VarChar, Nome),
        //                DB.MakeParam("@Sobrenome", SqlDbType.VarChar, Sobrenome),
        //                DB.MakeParam("@Username", SqlDbType.VarChar,Username),
        //                DB.MakeParam("@Senha", SqlDbType.VarChar, Senha),
        //                DB.MakeParam("@Tipo", SqlDbType.Int, Convert.ToInt32(TipoUsuario))
        //            };
        //            DB.executeSqlWithParameters(sql, paramsPost);
        //            Id = GetLastID();
        //            break;
        //        case RecordState.Update:
        //            sql = " UPDATE Usuario SET Nome = @Nome, Sobrenome = @Sobrenome, "
        //                + " Username = @Username, Senha = @Senha, Tipo = @Tipo "
        //                + " WHERE ID = @ID";
        //            paramsPost = new SqlParameter[] {
        //                DB.MakeParam("@Nome", SqlDbType.VarChar, Nome),
        //                DB.MakeParam("@Sobrenome", SqlDbType.VarChar, Sobrenome),
        //                DB.MakeParam("@Username", SqlDbType.VarChar,Username),
        //                DB.MakeParam("@Senha", SqlDbType.VarChar, Senha),
        //                DB.MakeParam("@Tipo", SqlDbType.Int, Convert.ToInt32(TipoUsuario)),
        //                DB.MakeParam("@ID", SqlDbType.Int, Id)
        //            };
        //            DB.executeSqlWithParameters(sql, paramsPost);
        //            break;
        //        case RecordState.Delete:
        //            DB.executeSql(" DELETE FROM Usuario WHERE ID = " + Id);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public override string ToString()
        {
            return Name + " " + "(" + EMail + ")";
        }

        #endregion

    }

    

}
