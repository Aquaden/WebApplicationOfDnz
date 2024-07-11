using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationOfDnz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        string constring = "Server =.;Database = Example;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        [HttpPost(Name = "PostProducts")]
        public bool Post(ProductDetails product)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[AddProduct]", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@prod", product.Name);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@cnt", product.Count);
                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }



        }

        [HttpGet(Name = "GetProducts")]
        public List<ProductDetails> GetProduct()
        {
            List<ProductDetails> pr = new List<ProductDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    using (SqlDataAdapter dt = new SqlDataAdapter("[dbo].[GetProduct]", con))
                    {

                        DataTable table = new DataTable();
                        dt.Fill(table);
                        try
                        {
                            if(table.Rows.Count > 0)
                            {

                                for(int i=0;i<table.Rows.Count;i++) 
                                {
                                    ProductDetails pd = new ProductDetails();
                                    pd.Name = table.Rows[i]["Product"].ToString();
                                    pd.Id = (int)table.Rows[i]["Id"];
                                    pd.Price = Convert.ToSingle(table.Rows[i]["Price"]);
                                    pd.Count =(int) table.Rows[i]["Count"];
                                    pr.Add(pd);

                                }
                            }
                            else
                            {
                                Console.WriteLine("Data tapilmadi");
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pr;

        }


    }
}
