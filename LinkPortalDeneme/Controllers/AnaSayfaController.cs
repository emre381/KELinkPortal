using Microsoft.AspNetCore.Mvc;
using LinkPortalDeneme.Models; //modeli dahil edip context sınıfından nesne türettim
using Microsoft.Data.SqlClient;

namespace LinkPortalDeneme.Controllers
{
    public class AnaSayfaController : Controller
    {

       /* LinkPortalTestContext c = new LinkPortalTestContext();*/// c nesnesi ile contextin içindeki sınıflara ulaşacağım



        public IActionResult Index()
        {
            //var degerler=c.LinkCategories.ToList();



            List<DbModal> List = new List<DbModal>();
            //List<DbModal2> List2 = new List<DbModal2>();

            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), LinkDesc = dr["Aciklama"].ToString(), LinkUrl = dr["Url"].ToString(), ProdUrl = dr["ProdUrl"].ToString(), PreProdUrl = dr["PreProdUrl"].ToString(), TestUrl = dr["TestUrl"].ToString() });
                }
            }


            
            dr.Close();
            cmd.Dispose();



            //SqlCommand cmd1 = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            //cnc.Open();

            //SqlDataReader dr1 = cmd.ExecuteReader();


            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        List.Add(new DbModal2 { LinkUrl = dr["Url"].ToString() });
            //    }
            //}


            //dr.Close();
            //cmd.Dispose();


            cnc.Close();


            return View(List);
        }

        public IActionResult ProdLink()
        {

            List<DbModal> List = new List<DbModal>();
            

            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), ProdUrl = dr["ProdUrl"].ToString() });
                }
            }


            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);
        }

        public IActionResult PreProdLink()
        {
            List<DbModal> List = new List<DbModal>();


            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), PreProdUrl = dr["PreProdUrl"].ToString() });
                }
            }


            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);

        }

        public IActionResult TestLink()
        {
            List<DbModal> List = new List<DbModal>();


            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), TestUrl = dr["TestUrl"].ToString() });
                }
            }


            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);
        }


    }
}
