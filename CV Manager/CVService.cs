using System.Web;
namespace CV_Manager {
    public class CVService {
        AppDbContext db;
        public CVService(AppDbContext context) {
            db = context;
        }

        /// <summary>
        /// Creates a new CV record in the database
        /// </summary>
        /// <param name="cv">The model contained all the required data for the record</param>
        /// <returns>The id of the new CV record</returns>
        public async Task<int> CreateCV(CVModel model) {
            CV cv = model.ToCV();
            db.Add(cv);
            await db.SaveChangesAsync();
            return cv.cvId;
        }

        public async Task<CV> GetCV(int id) {
            return await db.CVs
                .Where(r => r.cvId == id)
                .Select(r => new CV {
                    cvId = r.cvId,
                    firstName = r.firstName,
                    lastName = r.lastName,
                    birthDay = r.birthDay,
                    nationality = r.nationality,
                    gender = r.gender,
                    java = r.java,
                    cs = r.cs,
                    python = r.python,
                    beef = r.beef,
                    email = r.email,
                    photo = r.photo,
                    grade = r.grade,
                })
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Loads all the cvs and their infromation from the database
        /// </summary>
        /// <returns>An ICollection list of all the cvs of type CV</returns>
        public async Task<ICollection<CV>> LoadAllCVs() {
            return await db.CVs
                .Select(r => new CV {
                    cvId = r.cvId,
                    firstName = r.firstName,
                    lastName = r.lastName,
                    birthDay = r.birthDay,
                    nationality = r.nationality,
                    gender = r.gender,
                    java = r.java,
                    cs = r.cs,
                    python = r.python,
                    beef = r.beef,
                    email = r.email,
                    photo = r.photo,
                    grade = r.grade,
                })
                .ToListAsync();
        }

        /// <summary>
        /// Updates the CV entry in the database with the new info
        /// </summary>
        /// <param name="id">The CV id to be modified</param>
        /// <returns>The modified CV id</returns>
        public async Task<int> EditCV(int id, CV updated) {
            CV cv = await db.CVs.FindAsync(id);

            if (cv == null)
                throw new Exception("CV could not be found");

            DeleteImage("wwwroot/CVImages/" + cv.photo);
            UpdateInfo();
            await db.SaveChangesAsync();
            
            return cv.cvId;

            void UpdateInfo() {
                cv.firstName = updated.firstName;
                cv.lastName = updated.lastName;
                cv.birthDay = updated.birthDay;
                cv.nationality = updated.nationality;
                cv.gender = updated.gender;
                cv.java = updated.java;
                cv.cs = updated.cs;
                cv.python = updated.python;
                cv.beef = updated.beef;
                cv.email = updated.email;
                cv.photo = updated.photo;
            }
        }

        public async Task DeleteCV(int id) {
            CV cv = await db.CVs.FindAsync(id);

            DeleteImage("wwwroot/CVImages/" + cv.photo);

            db.Remove(cv);
            await db.SaveChangesAsync();
        }

        void DeleteImage(string path) {
            if (File.Exists(path))
                File.Delete(path);
            else {
                throw new Exception("Image not found");
            }
        }

        public int CalculateGrade(CV cv) {
            if (cv == null)
                return 0;

            int grade = 0;

            if (cv.java)
                grade += 10;
            if (cv.cs)
                grade += 10;
            if (cv.python) 
                grade += 10;
            if (cv.beef)
                grade += 10;

            grade = cv.gender.Equals("Male") ? grade + 5 : grade + 10;
        
            return grade;
        }

        public void CalculateGrade(CVModel cv) {
            if (cv == null)
                throw new Exception("CV does not exist!");

            int grade = 0;

            if (cv.java)
                grade += 10;
            if (cv.cs)
                grade += 10;
            if (cv.python)
                grade += 10;
            if (cv.beef)
                grade += 10;

            grade = cv.gender.Equals("Male") ? grade + 5 : grade + 10;

            cv.grade = grade;
        }
    }
}
