using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebShapes.DAL
{
	public class ShapeStorage
	{

		public void SaveShapesCollection(string shapesCollectionString, string userName)
		{

			string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// TODO add try-catch
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand("sp_SaveShapesCollectionForUser", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@UserName", userName));
				cmd.Parameters.Add(new SqlParameter("@ShapesCollection", shapesCollectionString));
				cmd.ExecuteScalar();

				conn.Close();

			}

		}

		public string QueryShapesCollection(string userName)
		{
			string shapesCollectionString = "";
			string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// TODO add try-catch
			using (SqlConnection conn = new SqlConnection(connString))
			{

				conn.Open();

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add(new SqlParameter("@UserName", userName));
				cmd.CommandText = "SELECT Shapes FROM tblShapesToUsers WHERE UserName = @UserName";

				shapesCollectionString = (string)cmd.ExecuteScalar();

				conn.Close();

			}

			return shapesCollectionString;

		}

	}

}