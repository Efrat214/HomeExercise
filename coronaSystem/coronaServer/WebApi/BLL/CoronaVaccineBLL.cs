using DAL;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CoronaVaccineBLL : ICoronaVaccineBLL
    {
        ICoronaVaccineDAL coronaVaccineDAL;
        public CoronaVaccineBLL(ICoronaVaccineDAL coronaVaccineDAL)
        {
            this.coronaVaccineDAL = coronaVaccineDAL;
        }
        public int AddCoronavaccine(Coronavaccine c)
        {
            return coronaVaccineDAL.AddCoronavaccine(c);
        }


        public List<Coronavaccine> GetAllCoronavaccine()
        {
            return coronaVaccineDAL.GetAllCoronavaccine();
        }

        public Coronavaccine GetCoronavaccineById(int Id)
        {
            return coronaVaccineDAL.GetCoronavaccineById(Id);
        }

    }
}
