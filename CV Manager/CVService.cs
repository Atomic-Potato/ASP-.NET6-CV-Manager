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
    }
}
