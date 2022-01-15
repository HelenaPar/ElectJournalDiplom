using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class TimetableService : ITimetableService
    {
        private readonly IRepository<Timetable> timetableRepository;

        public TimetableService(IRepository<Timetable> timetableRepository)
        {
            this.timetableRepository = timetableRepository;
        }
        public int? Add(Timetable timetable)
        {
            timetableRepository.Add(timetable);
            return timetable.Id;
        }

        public void Delete(int id)
        {
            timetableRepository.Delete(id);
        }

        public Timetable Get(int id)
        {
            var item = timetableRepository.Get(id);
            return item;
        }

        public IEnumerable<Timetable> Search(DayOfWeek day, int GroupId, DateTime begin, DateTime end)
        {
            return timetableRepository.List(new TimetableFilterSpecification(begin, end, day, GroupId));
        }
    }
}
