using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;

namespace TE.Core.Services
{
    internal interface ItacheService:IService<Tache>
    {
        int nombredetache(string matricule);
        int duremoyennetachefermee(DateTime dd, DateTime df);
        IList<Tache> tachesparprojets();
    }
}
