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
    }
}
