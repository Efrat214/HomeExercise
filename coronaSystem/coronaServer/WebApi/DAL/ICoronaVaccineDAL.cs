using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICoronaVaccineDAL
    {
        List<Coronavaccine> GetAllCoronavaccine();
        Coronavaccine GetCoronavaccineById(int Id);

        int AddCoronavaccine(Coronavaccine c);
    }
}
