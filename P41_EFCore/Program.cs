namespace DB_First
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // "Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"

            // SELECT

            //using (HospitalDbContext db = new HospitalDbContext())
            //{
            //    var doctors = db.Doctors.Where(d => d.Salary > 3000).ToList();
            //    foreach (var doctor in doctors)
            //    {
            //        Console.WriteLine(doctor);
            //    }
            //}

            //// INSERT
            //using (HospitalDbContext db = new HospitalDbContext())
            //{
            //    Doctor newDoctor = new Doctor()
            //    {
            //        Name = "John",
            //        Surname = "Doe",
            //        Salary = 4500,
            //        IsDeleted = false
            //    };
            //    db.Doctors.Add(newDoctor);
            //    db.SaveChanges();
            //}


            // UPDATE

            //using (HospitalDbContext db = new HospitalDbContext())
            //{
            //    var doctor = db.Doctors.FirstOrDefault(d => d.Id == 16);
            //    if (doctor != null)
            //    {
            //        doctor.Name = "Maria";
            //        doctor.Surname = "Smith";
            //        doctor.Salary = 5000;
            //        db.SaveChanges();
            //    }
            //}


            // DELETE   
            using (HospitalDbContext db = new HospitalDbContext())
            {
                var doctor = db.Doctors.FirstOrDefault(d => d.Id == 17);
                if (doctor != null)
                {
                    db.Doctors.Remove(doctor);
                    db.SaveChanges();
                }
            }

        }
    }
};
