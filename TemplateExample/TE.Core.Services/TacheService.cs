using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;
using TE.Core.Interfaces;

namespace TE.Core.Services
{
    internal class TacheService : Service<Tache>, ItacheService
    {
        public TacheService(IUnitOfWork uow) : base(uow)
        {
        }

        public int duremoyennetachefermee(DateTime dd, DateTime df)
        {
            int a = GetAll().Where(h => h.DateFin < DateTime.Now).Count();
            return ((int)(GetAll().Where(h => h.DateFin < DateTime.Now).Sum(h => (h.DateFin - h.DateDebut).TotalDays) / a));
        }

        public int nombredetache(string matricule)
        {
            return GetAll().Where(h => h.MyMembre.Matricule == matricule && h.DateFin < DateTime.Now).Count();
        }

        public IList<Tache> tachesparprojets()
        {
            return (IList<Tache>)GetAll().GroupBy(h => h.MySprint.MyProjet.Titre).ToList();
        }
    }
}
