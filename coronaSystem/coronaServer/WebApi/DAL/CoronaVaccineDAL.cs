using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CoronaVaccineDAL : ICoronaVaccineDAL
    {
        CoronadetailsDbContext db =new CoronadetailsDbContext();
        public int AddCoronavaccine(Coronavaccine c)
        {
            db.Coronavaccines.Add(c);
            db.SaveChanges();
            return c.Id;               
        }
        public List<Coronavaccine> GetAllCoronavaccine()
        {
            return db.Coronavaccines.ToList();
        }

        public Coronavaccine GetCoronavaccineById(int Id)
        {
            return db.Coronavaccines.FirstOrDefault(x => x.Id == Id);
        }
    }
}
