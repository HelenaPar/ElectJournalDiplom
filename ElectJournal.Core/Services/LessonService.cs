using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class LessonService : ILessonsService
    {
        private IRepository<Lesson> repository;

        public LessonService(IRepository<Lesson> repository)
        {
            this.repository = repository;
        }
        public int? Add(Lesson lesson)
        {
            var item = repository.Add(lesson);
            return item.Id;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Lesson Get(int id)
        {
            var item = repository.Get(id);
            return item;
        }
    }
}
