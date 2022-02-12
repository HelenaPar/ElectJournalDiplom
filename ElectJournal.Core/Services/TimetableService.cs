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
        private readonly IRepository<Timetable> TimetableRepository;
        private readonly ITimeService TimeService;

        public TimetableService(IRepository<Timetable> timetableRepository, ITimeService timeService)
        {
            this.TimetableRepository = timetableRepository;
            this.TimeService = timeService;
        }
        public int Add(Timetable timetable)
        {
            TimetableRepository.Add(timetable);
            return timetable.Id;
        }

        public void Delete(int id)
        {
            TimetableRepository.Delete(id);
        }

        public Timetable Get(int id)
        {
            var item = TimetableRepository.Get(id);
            return item;
        }

        public IEnumerable<Timetable> Search(DayOfWeek day, int groupId, DateTime begin, DateTime end)
        {
            return TimetableRepository.List(new TimetableSpecification(begin, end, day, groupId));
        }

        public IList<Timetable> TeachTimetable(int userId)
        {
            return TimetableRepository.List(new TimetableForTeachSpecification(TimeService.BeginDate(), TimeService.EndDate(), userId));
        }

        public IList<Timetable> StudTimetable(int groupId)
        {
            return TimetableRepository.List(new TimetableForStudSpecification(TimeService.BeginDate(), TimeService.EndDate(), groupId));
        }
    }
}
