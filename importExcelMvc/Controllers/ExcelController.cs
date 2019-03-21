using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importExcelMvc.Controllers
{
    public class ExcelController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public ExcelController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> OnPostExport()
        {
            string aPastaRaiz = _hostingEnvironment.WebRootPath;
            string oNomeDoArquivo = @"testedeexportacao.xlsx";
            string URL = $"{Request.Scheme}://{Request.Host}/{oNomeDoArquivo}";
            FileInfo arquivo = new FileInfo(Path.Combine(aPastaRaiz, oNomeDoArquivo));
            var memoria = new MemoryStream();
            using (var streamDeDados = new FileStream(Path.Combine(aPastaRaiz, oNomeDoArquivo), FileMode.Create, FileAccess.Write))
            {
                IWorkbook pastaDeTrabalhoExcel;
                pastaDeTrabalhoExcel = new XSSFWorkbook();
                ISheet planilhaExcel = pastaDeTrabalhoExcel.CreateSheet("PrimeiraPlanilha");
                IRow row = planilhaExcel.CreateRow(0);

                row.CreateCell(0).SetCellValue("Id");
                row.CreateCell(1).SetCellValue("Nome");
                row.CreateCell(2).SetCellValue("Condomínio");
                row.CreateCell(3).SetCellValue("Endereço");
                row.CreateCell(4).SetCellValue("Telefone");

                row = planilhaExcel.CreateRow(1);
                row.CreateCell(0).SetCellValue(1);
                row.CreateCell(1).SetCellValue("Jorge D'Orebe Vargas Gutierez");
                row.CreateCell(2).SetCellValue("RESDENCIAL MESTRE D'ARMAS");
                row.CreateCell(3).SetCellValue("SQN QUADRA 6 CONJUNTO B CASA 12");
                row.CreateCell(4).SetCellValue("(61) 3326-3214");

                row = planilhaExcel.CreateRow(2);
                row.CreateCell(0).SetCellValue(2);
                row.CreateCell(1).SetCellValue("Valdir Diniz de Bragança Olivae");
                row.CreateCell(2).SetCellValue("RESDENCIAL ABELHA DO CERRADO");
                row.CreateCell(3).SetCellValue("STN QUADRA 12 CONJUNTO C CASA 24");
                row.CreateCell(4).SetCellValue("(61) 3200-9854");

                row = planilhaExcel.CreateRow(3);
                row.CreateCell(0).SetCellValue(2);
                row.CreateCell(1).SetCellValue("Maria Inez Ibiapina de Sousa");
                row.CreateCell(2).SetCellValue("RESDENCIAL CALLED JUNINO");
                row.CreateCell(3).SetCellValue("QS 7 CONJUNTO 3 BLOCO K CASA 11");
                row.CreateCell(4).SetCellValue("(61) 3411-9654");

                pastaDeTrabalhoExcel.Write(streamDeDados);
            }
            using (var outroStream = new FileStream(Path.Combine(aPastaRaiz, oNomeDoArquivo), FileMode.Open))
            {
                await outroStream.CopyToAsync(memoria);
            }
            memoria.Position = 0;
            return File(memoria, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", oNomeDoArquivo);
        }

        public ActionResult OnPostImportar()
        {
            IFormFile arquivo = Request.Form.Files[0];
            string nomeDaPasta = "Subidos";
            string pastaRaiz = _hostingEnvironment.WebRootPath;
            string novoCaminho = Path.Combine(pastaRaiz, nomeDaPasta);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(novoCaminho))
            {
                Directory.CreateDirectory(novoCaminho);
            }
            if (arquivo.Length > 0)
            {
                string extensaoDoArquivo = Path.GetExtension(arquivo.FileName).ToLower();
                ISheet planilha;
                string caminhoCompleto = Path.Combine(novoCaminho, arquivo.FileName);
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                    stream.Position = 0;
                    if (extensaoDoArquivo == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); // Galera do Excel 97 até o 2k
                        planilha = hssfwb.GetSheetAt(0);
                    }
                    else
                    {
                        XSSFWorkbook xssfwb = new XSSFWorkbook(stream); // Excel 2007 em diante
                        planilha = xssfwb.GetSheetAt(0);
                    }
                    IRow linhaDoCabecalho = planilha.GetRow(0);
                    int contadorDeCelulas = linhaDoCabecalho.LastCellNum;
                    sb.Append("<table class='table'><tr>");
                    for (int i = 0; i < contadorDeCelulas; i++)
                    {
                        ICell celula = linhaDoCabecalho.GetCell(i);
                        if (celula == null || string.IsNullOrEmpty(celula.ToString())) continue;
                        sb.Append("<th>" + celula.ToString() + "</th>");
                    }
                    sb.Append("</th>");
                    sb.AppendLine("<th>");
                    for (int i = (planilha.FirstRowNum + 1); i <= planilha.LastRowNum; i++) // Faz a leitura do arquivo 
                    {
                        IRow linha = planilha.GetRow(i);
                        if (linha == null) continue;
                        if (linha.Cells.All(x => x.CellType == CellType.Blank)) continue;
                        for (int j = linha.FirstCellNum; j < contadorDeCelulas; j++)
                        {
                            if (linha.GetCell(j) != null)
                                sb.Append("<td>" + linha.GetCell(j).ToString() + "</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return this.Content(sb.ToString());
        }
    }
}