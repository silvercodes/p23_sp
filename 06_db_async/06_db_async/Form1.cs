using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _06_db_async
{
    public partial class Form1 : Form
    {
        private string connString = string.Empty;
        private SqlConnection conn;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();

            connString = ConfigurationManager
                .ConnectionStrings["express"]
                .ConnectionString;

            conn = new SqlConnection(connString);

            dt = new DataTable();
        }

        private async void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn is null)
                    throw new Exception("Invalid connection...");

                await conn.OpenAsync();                                    // BLOCKING CALL

                string query = $"WAITFOR DELAY '00:00:10'; {txtQuery.Text}";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();     // BLOCKING CALL

                // dt.Load(reader);                                // BLOCKING CALL
                // await Task.Run(() => dt.Load(reader));
                await LoadToTableAsync(reader);

                dgvMain.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn is not null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private Task LoadToTableAsync(SqlDataReader reader)
        {
            return Task.Run(() => dt.Load(reader));
        }
    }
}
