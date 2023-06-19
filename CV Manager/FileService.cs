using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CV_Manager {
    public class FileService {

        /// <summary>
        /// Saves the submitted image to the following path:
        /// wwwroot/CVImages
        /// </summary>
        /// <returns>The new unique image name</returns>
        public string SaveImage(IFormFile image) {
            string fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string savePath = "wwwroot/CVImages/" + fileName;

            using (var fileStream = new FileStream(savePath, FileMode.Create)) {
                image.CopyTo(fileStream);
            }

            return fileName;
        }

        /// <summary>
        /// Deletes the image in the given path
        /// </summary>
        /// <param name="path">The image path</param>
        /// <exception cref="Exception">Image could not be found</exception>
        public void DeleteImage(string path) {
            if (File.Exists(path))
                File.Delete(path);
            else {
                throw new Exception("Image not found");
            }
        }

        public byte[] ConvertToPDF(CV cv) {
            Document pdfDoc = new Document();
            
            // A memory stream to write the PDF content
            MemoryStream stream = new MemoryStream();
            // A PDF writer to write the document to the stream
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            pdfDoc.Open();
            FillDocument();
            pdfDoc.Close();

            return stream.ToArray();

            void FillDocument() {
                Image image = Image.GetInstance("wwwroot/CVImages/" + cv.photo);
                image.ScaleToFit(new Rectangle(0, 0, 200, 200));

                Font nameFont = new Font(Font.FontFamily.HELVETICA, 20f, Font.BOLD);
                Paragraph name = new Paragraph(cv.firstName + " " + cv.lastName, nameFont);

                Font gradeFont = new Font(Font.FontFamily.HELVETICA, 30f, Font.BOLD);
                Paragraph grade = new Paragraph("Grade: " + cv.grade, gradeFont);

                Paragraph desc = new Paragraph(
                    cv.gender + " born in " + cv.nationality + " on " + cv.birthDay + "\n"
                    + "Email: " + @cv.email);

                List skills = new List(List.UNORDERED);
                if (cv.java)
                    skills.Add("Java");
                if (cv.cs)
                    skills.Add("C#");
                if (cv.python)
                    skills.Add("Python");
                if (cv.beef)
                    skills.Add("Beef");

                pdfDoc.Add(image);
                pdfDoc.Add(name);
                pdfDoc.Add(desc);
                pdfDoc.Add(skills);
                pdfDoc.Add(grade);
            }
        }
    }
}
