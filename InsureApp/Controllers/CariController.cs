using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsureApp.Business.Abstract;
using InsureApp.Entities.Concrete;
using InsureApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;


namespace InsureApp.Controllers

{ 
    public class CariController : Controller
    {
        private IOdemelerService _odemelerService;
        private IMusteriService _musteriservice;
        private IPoliceService _policeService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CariController(IOdemelerService odemelerService,
                                  IPoliceService policeService,
                                  IMusteriService musteriService,
                                  IHostingEnvironment hostingEnvironment)
        {
            _odemelerService = odemelerService;
            _policeService = policeService;
            _musteriservice = musteriService;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult ExportToPDF(int musteri = 0)
        {
            /* URL den PDF URETME olayı burada
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl("http://localhost:49737/Cari/Index");

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;

            */


            
            // burada sayfa boyutu veriyorsun aynen printerdaki gibi
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                "A4", true);

            //burada da yatay dikey secenegi aynen printerdaki gibi
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    "Portrait", true);

            int webPageWidth = 1024;


            int webPageHeight = 0;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            var odeme = _odemelerService.GetAll();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body><table border='1' width='100%'><tr style='color:red'><td style='color:blue'>Poliçe No</td> <td> Musteri Adı </td> <td> Ödeme Tarihi </td><td> Ödenen Tutar </td><td> Borç </td> <td> Alacak </td></tr>");

            foreach (Odemeler item in odeme)
            {
                sb.Append("<tr>");
                var alacak = 0;
                var borc = 0 - item.Odenen_tutar; 
                if (item.Odenen_tutar > 0)
                {
                    borc = 0;
                    alacak = item.Odenen_tutar - 0;
                }
                else
                { 
                    borc = 0 - item.Odenen_tutar;
                }


                sb.Append("<td> " + item.Police_no + "</td>");
                sb.Append("<td> " + "Hakan Mehmet" + "</td>"); 
                sb.Append("<td> " + item.Odeme_tarihi +"</td>");
                sb.Append("<td> " + item.Odenen_tutar + "</td>");
                sb.Append("<td> " + borc + " </td>");
                sb.Append("<td> "+"0" +"</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table></body></html>");
            PdfDocument doc = converter.ConvertHtmlString(sb.ToString(), "");

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;

           





            /*
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");
            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Convert URL to PDF
            PdfDocument document = htmlConverter.Convert("~/Views/Cari/Index.cshtml");
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Sample.pdf");
            */
        }

        public ActionResult Index(int page = 1, int musteri = 0)
        {
            int pageSize = 10;
            var odeme = _odemelerService.GetByMusteriId(musteri);
            CariListViewModel model = new CariListViewModel()
            {
                Odemeler = FixModel(odeme.Skip((page - 1) * pageSize).Take(pageSize).ToList()),
                PageCount = (int)Math.Ceiling(odeme.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = musteri,
                CurrentPage = page
            };
            return View(model);
        }

        private List<OdemelerModel> FixModel(List<Odemeler> toList)
        {
            var result = new List<OdemelerModel>();
            foreach (var item in toList)
            {
                var row = new OdemelerModel();
                var musteri = _musteriservice.GetById(item.Musteri_id);
                var police = _policeService.GetById(item.Police_no);

                row.SigortaBedeli = police.Sigorta_bedeli;
                row.Ad = musteri.Isim;
                row.Soyad = musteri.Soyisim;
                row.FullName = string.Format("{0} {1}", row.Ad, row.Soyad);
                //row.Musteri_id = item.Musteri_id;
                row.Odeme_id = item.Odeme_id;
                row.Odeme_tarihi = item.Odeme_tarihi;
                row.Odenen_tutar = item.Odenen_tutar;
                row.Police_no = police.Police_no;

                result.Add(row);
            }

            return result;
        }


        private List<MusteriModel> FixMusterModel(List<Musteri> list)
        {
            var result = new List<MusteriModel>();
            foreach (var item in list)
            {
                var row = new MusteriModel();
                //row.FullName = item.Isim + item.Soyisim;
                row.FullName = string.Format("{0}  {1}", item.Isim, item.Soyisim);
                row.Musteri_id = item.Musteri_id;

                result.Add(row);
            }

            return result;
        }

        [HttpPost]
        public ActionResult Add(Odemeler odemeler)
        {
            if (ModelState.IsValid)
            {
                _odemelerService.Add(odemeler);

                // TempData.Add("message","Poliçe başarıyla eklendi");

            }

            return RedirectToAction("Add");

        }
        public ActionResult Update(Odemeler odemeler)
        {
            //if (ModelState.IsValid)
            //{
            //    _odemelerService.Update(odemeler);
            //    //TempData.Add("Mesaj", "Müşteri güncelleme işlemi gerçekleşti.");
            //}
            //return RedirectToAction("Index");
            return View();
        }
        //public ActionResult Delete(int odemeID)
        //{
        //    _odemelerService.Delete(odemeID);
        //    //TempData.Add("Mesaj", "Müşteri silme işlemi gerçekleşti.");
        //    return RedirectToAction("Index");
        //}
    }
}
