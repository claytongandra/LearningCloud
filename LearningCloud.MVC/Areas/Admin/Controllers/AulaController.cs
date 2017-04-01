using System.Web.Mvc;
using System.Collections.Generic;
using AutoMapper;
using PagedList;
using LearningCloud.Application.Interfaces;
using LearningCloud.Domain.Entities;
using LearningCloud.MVC.Areas.Admin.ViewModels;
using System.Web;
using System;
using System.IO;
using System.Net;


namespace LearningCloud.MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class AulaController : Controller
    {
        private readonly IAulaAppService _aulaApp;
        private readonly IAssinaturaNivelAppService _assinaturaNivelApp;
        
        public AulaController(IAulaAppService aulaApp, IAssinaturaNivelAppService assinaturaNivelApp)
        {
            _aulaApp = aulaApp;
            _assinaturaNivelApp = assinaturaNivelApp;
        }

        // GET: Admin/Aula
        public ActionResult Index(int? page)
        {
            int paginaTamanho = 2;
            int paginaNumero = (page ?? 1);

            var aulaViewModel = Mapper.Map<IEnumerable<Aula>, IEnumerable<AulaViewModel>>(_aulaApp.GetAll());

            ViewBag.page = page;

            return View(aulaViewModel.ToPagedList(paginaNumero, paginaTamanho));
        }

        // GET: Admin/Aula/Details/5
        public ActionResult Details(int id, int? page)
        {
            var aula = _aulaApp.GetById(id);
            var aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            ViewBag.page = page;

            return View(aulaViewModel);
        }

        // GET: Admin/Aula/Create
        public ActionResult Create(int? page)
        {
            ViewBag.assinaturanivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"), "AssinaturaNivel_Id", "asn_titulo");
            ViewBag.page = page;

            return View();
        }

        // POST: Admin/Aula/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AulaViewModel aula, int? page)
        {
            if (ModelState.IsValid)
            {
                var aulaDomain = Mapper.Map<AulaViewModel, Aula>(aula);

                _aulaApp.CreateAula(aulaDomain);

                return RedirectToAction("Index");
            }

            ViewBag.assinaturanivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"), "AssinaturaNivel_Id", "asn_titulo", aula.aul_fk_assinaturanivel);
            ViewBag.page = page;

            return View(aula);
        }

        // GET: Admin/Aula/Edit/5
        public ActionResult Edit(int id, int? page, string returnaction)
        {
            var aula = _aulaApp.GetById(id);
            var aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            if (returnaction == "" || returnaction == null)
            {
                returnaction = "Index";
            }

            ViewBag.assinaturanivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"), "AssinaturaNivel_Id", "asn_titulo", aulaViewModel.aul_fk_assinaturanivel);
            ViewBag.page = page;
            ViewBag.ReturnAction = returnaction;

            return View(aulaViewModel);

        }

        // POST: Admin/Aula/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AulaViewModel aula, int? page, string returnaction)
        {
            if (ModelState.IsValid)
            {
                var aulaDomain = Mapper.Map<AulaViewModel, Aula>(aula);

                _aulaApp.UpdateAula(aulaDomain);

                return RedirectToAction((string)returnaction, new { page = page });
            }

            ViewBag.assinaturanivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A,I"), "AssinaturaNivel_Id", "asn_titulo", aula.aul_fk_assinaturanivel);
            ViewBag.page = page;
            ViewBag.ReturnAction = returnaction;

            return View(aula);

        }

        // GET: Admin/Aula/Delete/5
        public ActionResult Delete(int id, int? page)
        {
            var aula = _aulaApp.GetById(id);
            var aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            ViewBag.page = page;

            return View(aulaViewModel);

        }

        // POST: Admin/Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var aula = _aulaApp.GetById(id);

            _aulaApp.RemoveAula(aula);

            return RedirectToAction("Index");
        }

        // GET: Aula/Inactivate/5
        public ActionResult Inactivate(int id, int? page)
        {
            var aula = _aulaApp.GetById(id);
            var aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            ViewBag.page = page;

            return View(aulaViewModel);
        }

        // POST: Aula/Inactivate/5
        [HttpPost, ActionName("Inactivate")]
        [ValidateAntiForgeryToken]
        public ActionResult InactivateConfirmed(int id, int? page)
        {
            var aula = _aulaApp.GetById(id);

            _aulaApp.ChangeStatusAula(aula, "I");

            return RedirectToAction("Index", new { page = page });
        }

        // GET: Aula/Activate/5
        public ActionResult Activate(int id, int? page)
        {
            var aula = _aulaApp.GetById(id);

            _aulaApp.ChangeStatusAula(aula, "A");

            return RedirectToAction("Index", new { page = page });
        }

       

        [HttpPost]
        public JsonResult AdicionarVideo(HttpPostedFileBase filevideo)
        {

            string resultadoUpImagem = null;
         
            try
            {

                
                if (filevideo != null)
                {
                    string fileExt = Path.GetExtension(filevideo.FileName).Replace(@".", @"").ToLower();

                    if (filevideo.ContentLength > 0)
                    {
                         if (fileExt != "mp4" && fileExt != "webm" && fileExt != "mkv")
                        {
                            //  Response.Status = "804 Tipo de arquivo não permitido";
                            Response.Status = "804 Tipo de arquivo não permitido.  <br />Selecione apenas arquivos de video (.mp4, .webm ou .mkv). ";

                        }
                        else
                        {
                            //var v = file.ContentLength;
                            //if (file.ContentLength > 3145728)  //3145728  bytes  = 3 Mb
                            //{
                            //    ViewBag.Message = "O Tamanho do arquivo não permitido. <br />Selecione um video de até 3Mb";
                            //    ViewBag.Status = -1;
                            //    return PartialView();
                            //}
                            //else
                            //{
                                resultadoUpImagem = UploadVideoaula.UploadFileVideoaula(filevideo);

                                
                            //}
                        }
                    }
                    else
                    {
                        Response.Status = "802 O Conteudo do Arquivo está vazio. ";

                    }
                }
                else
                {
                    Response.Status = "803 O Arquivo é nullo.";

                }
            }
            catch (WebException e)
            {
                resultadoUpImagem = e.Response.ToString();
            }

            return Json(resultadoUpImagem);

        }

    }
}
