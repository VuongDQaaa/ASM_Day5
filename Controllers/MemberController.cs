using Microsoft.AspNetCore.Mvc;
using ASM_Day5.Services;
using System.Data;
using ASM_Day5.Models;
using ClosedXML.Excel;
namespace ASM_Day5.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberservice _memberService;
        private readonly ILogger<MemberController> _logger;
        public MemberController(ILogger<MemberController> logger, IMemberservice memberservice)
        {
            _logger = logger;
            _memberService = memberservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult MaleMember()
        {
            return Ok(_memberService.GetMaleMember());
        }
        public IActionResult OldestMember()
        {
            return Ok(_memberService.OldestMember());
        }
        public IActionResult GetMemberByYear(int year)
        {
            return Ok(_memberService.GetMemberByYear(year));
        }
        public IActionResult GetFullName()
        {
            return Ok(_memberService.GetFullName());
        }
        public FileResult ExportExcelFile()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[2] { new DataColumn("First Name"), new DataColumn("LastName") });
            foreach (Member member in _memberService.GetAllMember())
            {
                table.Rows.Add(member.FirstName, member.LastName);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "MemberWorsheet");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.speadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
    }
}