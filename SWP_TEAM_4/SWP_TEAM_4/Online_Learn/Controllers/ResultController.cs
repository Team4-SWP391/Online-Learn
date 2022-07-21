using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http;
using Online_Learn.AuthData;

namespace Online_Learn.Controllers {
    [AuthAttribute]
    public class ResultController : Controller {
        private readonly Online_LearnContext _context;

        public ResultController(Online_LearnContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List(int pageIndex, string? name, string? name_exam,
            DateTime? start, DateTime? end,
            double? to, double? from)
        {

            int pageSize = 10;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            if (name == null)
            {
                name = "";
            }
            else
            {
                ViewBag.name = name;
            }
            if (name_exam == null)
            {
                name_exam = "";
            }
            else
            {
                ViewBag.name_exam = name_exam;
            }
            if (start == null)
            {
                start = _context.Exams.Min(x => x.StartDate);
            }
            else
            {
                ViewBag.start = start;
            }
            if (end == null)
            {
                end = _context.Exams.Max(x => x.StartDate);
            }
            else
            {
                ViewBag.end = end;

            }
            if (to == null)
            {
                to = _context.Results.Min(x => x.Score);
            }
            else
            {
                ViewBag.to = to;
            }
            if (from == null)
            {
                from = _context.Results.Max(x => x.Score);
            }
            else
            {
                ViewBag.from = from;
            }

            var results = _context.Results.Include(x => x.Account).Include(x => x.Exam).
                Where(x => x.Account.FulllName.ToLower().Contains(name.ToLower()) &&
                x.Exam.StartDate >= start && x.Exam.StartDate <= end
                && x.Score >= to && x.Score <= from && x.Exam.ExamName.ToLower().Contains(name_exam.ToLower())).Skip(((pageIndex - 1) * pageSize)).
                Take(pageSize).ToList();

            int total_result = _context.Results.Include(x => x.Account).Include(x => x.Exam).
                Where(x => x.Account.FulllName.ToLower().Contains(name.ToLower()) &&
                x.Exam.StartDate >= start && x.Exam.StartDate <= end
                && x.Score >= to && x.Score <= from && x.Exam.ExamName.ToLower().Contains(name_exam.ToLower())).ToList().Count();

            int maxPage = total_result / pageSize + (total_result % pageSize != 0 ? 1 : 0);
            ViewBag.pageIndex = pageIndex;
            ViewBag.maxPage = maxPage;
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.results = results;
            return View();

        }

        public IActionResult Export()
        {
            var results = _context.Results.ToList();
            WriteExcel(results);
            var path = @"Results.xlsx";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Results.xlsx");
        }

        public IActionResult Import(IFormFile fileUpload)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "FileUpload", fileUpload.FileName);
            using (var file = new FileStream(path, FileMode.Create))
            {
                fileUpload.CopyTo(file);
            }
            ReadExcel(fileUpload.FileName);
            return Redirect("/Result/List?pageIndex=1");
        }

        public bool ResultExist(int id)
        {
            foreach (var item in _context.Results.ToList())
            {
                if (item.ResultId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReadExcel(string fileName)
        {
            var package = new ExcelPackage(new FileInfo("FileUpload/" + fileName));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            int totalRows = worksheet.Dimension.End.Row;
            for (int row = 2; row <= totalRows; row++)
            {
                Result rs = new Result();
                rs.ResultId = Convert.ToInt32(worksheet.Cells[row, 1].Value.ToString());
                rs.ExamId = Convert.ToInt32(worksheet.Cells[row, 2].Value.ToString());
                rs.AccountId = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString());
                rs.Score = Convert.ToDouble(worksheet.Cells[row, 4].Value.ToString());
                rs.CorrectAnswer = Convert.ToInt32(worksheet.Cells[row, 5].Value.ToString());
                rs.Status = worksheet.Cells[row, 6].Value.ToString();
                rs.Time = Convert.ToInt32(worksheet.Cells[row, 7].Value.ToString());
                if (!ResultExist(rs.ResultId))
                {
                    _context.Results.Add(rs);
                }
                _context.SaveChanges();
            }

        }
        public void WriteExcel(List<Result> results)
        {
            var package = new ExcelPackage();
            var workSheet = package.Workbook.Worksheets.Add("Results");

            workSheet.Cells["A1"].Value = "Result Id";
            workSheet.Cells["B1"].Value = "Exam Id";
            workSheet.Cells["C1"].Value = "Account Id";
            workSheet.Cells["D1"].Value = "Score";
            workSheet.Cells["E1"].Value = "CorrectAnswer";
            workSheet.Cells["F1"].Value = "Status";
            workSheet.Cells["G1"].Value = "Time";
            int row = 2;
            foreach (var result in results)
            {
                workSheet.Cells["A" + row].Value = result.ResultId;
                workSheet.Cells["B" + row].Value = result.ExamId;
                workSheet.Cells["C" + row].Value = result.AccountId;
                workSheet.Cells["D" + row].Value = result.Score;
                workSheet.Cells["E" + row].Value = result.CorrectAnswer;
                workSheet.Cells["F" + row].Value = result.Status;
                workSheet.Cells["G" + row].Value = result.Time;
                row++;
            }
            package.SaveAs(new FileInfo("Results.xlsx"));
        }


    }
}
