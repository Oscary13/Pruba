using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pruba.Views
{
    public partial class Images : System.Web.UI.Page
    {
        private string[] images = { "../Images/a.jpg", "../Images/b.jpg", "../Images/c.jpg", "../Images/d.jpg" };
        private static int currentIndex = 0;


        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        DisplayImage(currentIndex);
        //    }
        //}

        //protected void btnPrev_Click(object sender, EventArgs e)
        //{
        //    currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        //    DisplayImage(currentIndex);
        //}

        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    currentIndex = (currentIndex + 1) % images.Length;
        //    DisplayImage(currentIndex);
        //}

        //private void DisplayImage(int index)
        //{
        //    imgViewer.ImageUrl = images[index];
        //}

        private static List<byte[]> imageBytesList = new List<byte[]>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Convierte las rutas de las imágenes a bytes y agrega a la lista
                foreach (string imagePath in images)
                {
                    byte[] imageBytes = ConvertImageToBytes(Server.MapPath(imagePath));
                    imageBytesList.Add(imageBytes);
                }

                // Muestra la primera imagen
                DisplayImage(0);
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1 + imageBytesList.Count) % imageBytesList.Count;
            DisplayImage(currentIndex);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % imageBytesList.Count;
            DisplayImage(currentIndex);
        }


        private void DisplayImage(int index)
        {
            // Convierte los bytes a una imagen y la muestra en el control Image
            imgViewer.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageBytesList[index]);
        }

        private byte[] ConvertImageToBytes(string imagePath)
        {
            // Convierte la imagen en bytes
            byte[] imageBytes;

            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    imageBytes = br.ReadBytes((int)fs.Length);
                }
            }

            return imageBytes;
        }
    }
}