using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class MarkViewModelService : IMarkViewModelService
    {
        private readonly IMarkService markService;
        private readonly IRepository<Mark> repository;

        public MarkViewModelService(IMarkService markService, IRepository<Mark> repository)
        {
            this.markService = markService;
            this.repository = repository;
        }

        public IEnumerable<MarksViewModel> List(int GroupId)
        {
            return markService.List(GroupId).Select(ConvertToViewModel);
        }

        private MarksViewModel ConvertToViewModel(Mark mark)
        {
            return new MarksViewModel
            {
                Id = mark.Id,
                SubjectName = mark.Lesson.Subject.Name,
                LessonDate = mark.Lesson.Date,
                Value = mark.Value
            };
        }
    }
}
