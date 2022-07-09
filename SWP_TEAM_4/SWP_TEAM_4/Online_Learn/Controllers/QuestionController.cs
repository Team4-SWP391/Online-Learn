using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

using Online_Learn.Models;

namespace Online_Learn.Controllers {
    public class QuestionController : Controller {
        private readonly Online_LearnContext _context;

        public QuestionController(Online_LearnContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            List<Question> questionsSlider = _context.Questions.ToList();
            List<Question> questions = _context.Questions.Take(3).ToList();
            model.questionsSlider = questionsSlider;
            model.questions = questions;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, string quiz, string op1, string op2, string op3, string op4, string solution, int totalQuestion)
        {
            Question question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);
            question.Quiz = quiz;
            question.Op1 = op1;
            question.Op2 = op2;
            question.Op3 = op3;
            question.Op4 = op4;
            question.Solution = solution;
            _context.Update(question);
            _context.SaveChanges();
            List<Question> questions = new List<Question>();
            if (totalQuestion == 3)
            {
                questions = _context.Questions.Take(3).ToList();
            }
            else
            {
                questions = _context.Questions.ToList();

            }
            return PartialView("QuestionPartial", questions);
        }

        public IActionResult Delete(int id)
        {
            Question question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);
            _context.Remove(question);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult LoadMore()
        {
            List<Question> questions = _context.Questions.ToList();
            return PartialView("QuestionPartial", questions);
        }

        [HttpPost]
        public IActionResult ImportExcel(IFormFile fileUpload)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "FileUpload", fileUpload.FileName);
            using (var file = new FileStream(path, FileMode.Create))
            {
                fileUpload.CopyTo(file);
            }
            ReadExcel(fileUpload.FileName);
            return RedirectToAction("Index");
        }

        public void ReadExcel(string fileName)
        {
            var package = new ExcelPackage(new FileInfo("FileUpload/" + fileName));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            int totalRows = worksheet.Dimension.End.Row;
            for (int row = 2; row <= totalRows; row++)
            {
                Question question = new Question();
                question.Quiz = worksheet.Cells[row, 1].Value.ToString();
                question.Op1 = worksheet.Cells[row, 2].Value.ToString();
                question.Op2 = worksheet.Cells[row, 3].Value.ToString();
                question.Op3 = worksheet.Cells[row, 4].Value.ToString();
                question.Op4 = worksheet.Cells[row, 5].Value.ToString();
                question.Solution = worksheet.Cells[row, 6].Value.ToString();
                question.LectureId = 1;
                _context.Add(question);
                _context.SaveChanges();
            }

        }
        public IActionResult ExportExcel()
        {
            var questions = _context.Questions.ToList();
            WriteExcel(questions);
            var path = @"Questions.xlsx";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Questions.xlsx");
        }
        public void WriteExcel(List<Question> questions)
        {
            var package = new ExcelPackage();
            var workSheet = package.Workbook.Worksheets.Add("Questions");
            workSheet.Cells["A1"].Value = "Question";
            workSheet.Cells["B1"].Value = "Option 1";
            workSheet.Cells["C1"].Value = "Option 2";
            workSheet.Cells["D1"].Value = "Option 3";
            workSheet.Cells["E1"].Value = "Option 4";
            workSheet.Cells["F1"].Value = "Option 5";
            workSheet.Cells["G1"].Value = "LectureId";
            int row = 2;
            foreach (var question in questions)
            {
                workSheet.Cells["A" + row].Value = question.Quiz;
                workSheet.Cells["B" + row].Value = question.Op1;
                workSheet.Cells["C" + row].Value = question.Op2;
                workSheet.Cells["D" + row].Value = question.Op3;
                workSheet.Cells["E" + row].Value = question.Op4;
                workSheet.Cells["F" + row].Value = question.Solution;
                workSheet.Cells["G" + row].Value = question.LectureId;
                row++;
            }
            package.SaveAs(new FileInfo("Questions.xlsx"));
        }

      
    }
}
