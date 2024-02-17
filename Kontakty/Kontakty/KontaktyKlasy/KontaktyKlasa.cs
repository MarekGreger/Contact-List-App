using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty.KontaktyKlasy
{
    class KontaktyKlasa
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string AdresMailowy { get; set; }
        public string AdresZamieszkania { get; set; }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Dane_kontaktowe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception e)
            {
                // przynajmniej zaloguj wyjątek, aby wiedzieć, co poszło nie tak
                Console.WriteLine("Wystąpił wyjątek: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool Insert(KontaktyKlasa c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            string sql = "INSERT INTO Dane_kontaktowe (Imie, Nazwisko, Telefon, AdresMailowy, AdresZamieszkania) VALUES(@Imie, @Nazwisko, @Telefon, @AdresMailowy, @AdresZamieszkania)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Imie", c.Imie);
            cmd.Parameters.AddWithValue("@Nazwisko", c.Nazwisko);
            cmd.Parameters.AddWithValue("@Telefon", c.Telefon);
            cmd.Parameters.AddWithValue("@AdresMailowy", c.AdresMailowy);
            cmd.Parameters.AddWithValue("@AdresZamieszkania", c.AdresZamieszkania);
            // usuń @ID, ponieważ ID jest automatycznie generowane przez bazę danych (prawdopodobnie jako klucz główny)
            // cmd.Parameters.AddWithValue("@ID", c.ID);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił wyjątek: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Update(KontaktyKlasa c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Dane_kontaktowe SET Imie=@Imie, Nazwisko=@Nazwisko, Telefon=@Telefon, AdresMailowy=@AdresMailowy, AdresZamieszkania=@AdresZamieszkania WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Imie", c.Imie);
                cmd.Parameters.AddWithValue("@Nazwisko", c.Nazwisko);
                cmd.Parameters.AddWithValue("@Telefon", c.Telefon);
                cmd.Parameters.AddWithValue("@AdresMailowy", c.AdresMailowy);
                cmd.Parameters.AddWithValue("@AdresZamieszkania", c.AdresZamieszkania);
                cmd.Parameters.AddWithValue("@ID", c.ID); // dodaj @ID, ponieważ chcesz zaktualizować rekord o określonym ID
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił wyjątek: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Delete(KontaktyKlasa c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Dane_kontaktowe WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID); // dodaj @ID, ponieważ chcesz usunąć rekord o określonym ID
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił wyjątek: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
