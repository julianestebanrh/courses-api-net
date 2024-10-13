using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Courses.ReportExcelCourse;

public class ReportExcelCourseQuery
{
    public record ReportExcelCourseQueryRequest : IRequest<MemoryStream>;

    internal class ReportExcelCourseQueryHandler : IRequestHandler<ReportExcelCourseQueryRequest, MemoryStream>
    {
        private readonly MasterNetDbContext _context;
        private readonly IReportService<Course> _reportService;

        public ReportExcelCourseQueryHandler(MasterNetDbContext context, IReportService<Course> reportService)
        {
            _context = context;
            _reportService = reportService;
        }

        public async Task<MemoryStream> Handle(ReportExcelCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var courses = await _context.Courses!.Take(10).Skip(0).ToListAsync();
            return await _reportService.GetCsvReport(courses);
        }
    }

}