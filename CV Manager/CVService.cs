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
                    photo = r.photo
                })
                .SingleOrDefaultAsync();
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
    }
}
