using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace BLL
{
   public class BLLUser
    {
        public int CreateUser(string username, string password, string usertype, string fullname)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("insert into tblUser values(@a,@b,@c,@d)", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);
            cmd.Parameters.AddWithValue("@c", usertype);
            cmd.Parameters.AddWithValue("@d", fullname);
            con.Open();
           int i= cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable GetAllUser()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("select *from tblUser", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable CheckUserLogin(string username, string password, string usertype)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("select *from tblUser where Username=@a and Password=@b and Usertype=@c", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);
            cmd.Parameters.AddWithValue("@c", usertype);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable CheckOldUser(string username, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("select *from tblUser where Username=@a and Password=@b", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int UpdatePassword(string username, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("Update tblUser set Password=@b where Username=@a", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int UpdateUser(string username, string password, string usertype, string fullname, int id)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("update tblUser set Username=@a,Password=@b,Usertype=@c,Fullname=@d where Userid=@e", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);
            cmd.Parameters.AddWithValue("@c", usertype);
            cmd.Parameters.AddWithValue("@d", fullname);
            cmd.Parameters.AddWithValue("@e", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int DeleteUser( int id)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=NobelDB");
            SqlCommand cmd = new SqlCommand("delete from tblUser where Userid=@e", con);
            
            cmd.Parameters.AddWithValue("@e", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
