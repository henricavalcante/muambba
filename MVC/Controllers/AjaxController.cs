using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using BLL;
using System.IO;
using System.Drawing;

namespace MVC.Controllers
{
    public class AjaxController : ControllerBase
    {
        //
        // GET: /Ajax/

        public ActionResult RetornoPadrao()
        {
            if (Request.UrlReferrer == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("RetornoPadrao");
            }
        }

        public ActionResult PesquisaEndereco(string q)
        {
            
            RetornoAjax = BLLProcedures.stpEnderecoList(q).ToString();

            return RetornoPadrao();
        }


        public ActionResult RealizarLogoff()
        {
            UsuarioLogado_ID = null;
            UsuarioLogado_ADMIN = false;

            if (Request.UrlReferrer != null)
            {
                RetornoAjax = Request.UrlReferrer.ToString();
            }
            

            return RetornoPadrao();
        }

        public ActionResult RealizarPergunta(int a, string p)
        {
            
            var bll = new BLLAnuncioPergunta();

            var ap = new AnuncioPergunta();
            ap.DataInc = DateTime.Now;
            ap.Pergunta = p;
            ap.IdUsuarioInc = (int)UsuarioLogado_ID;
            ap.IdAnuncio = a;

            bll.InsertAndSave(ap);

            return RetornoPadrao();
        }

        public Size NewImageSize(int OriginalHeight, int OriginalWidth, double FormatSize)
        {
            Size NewSize;
            double tempval;

            if (OriginalHeight > FormatSize && OriginalWidth > FormatSize)
            {
                if (OriginalHeight > OriginalWidth)
                    tempval = FormatSize / Convert.ToDouble(OriginalWidth);
                else
                    tempval = FormatSize / Convert.ToDouble(OriginalHeight);

                NewSize = new Size(Convert.ToInt32(tempval * OriginalWidth), Convert.ToInt32(tempval * OriginalHeight));
            }
            else
            {
                NewSize = new Size(OriginalWidth, OriginalHeight);
            }
            
            return NewSize;
        }


        public ActionResult ExcluirFotoAnuncio(string NomeArquivo)
        {
            try
            {
                var path = @Server.MapPath("/Imagens/Anuncios/");
                System.IO.File.Delete(path + NomeArquivo);
                System.IO.File.Delete(path + NomeArquivo.Split('.')[0] + "s." + NomeArquivo.Split('.')[1]);
                System.IO.File.Delete(path + NomeArquivo.Split('.')[0] + "P." + NomeArquivo.Split('.')[1]);

                return Json(new { success = true }, "text/html");
            }
            catch (Exception)
            {

                return Json(new { success = false }, "text/html");
            }

        }

        public ActionResult ExcluirFotoUsuario(string NomeArquivo)
        {
            try
            {
                var path = @Server.MapPath("/Imagens/Usuarios/");

                System.IO.File.Delete(path + NomeArquivo);
                System.IO.File.Delete(path + NomeArquivo.Split('.')[0] + "s." + NomeArquivo.Split('.')[1]);
                System.IO.File.Delete(path + NomeArquivo.Split('.')[0] + "P." + NomeArquivo.Split('.')[1]);

                return Json(new { success = true }, "text/html");
            }
            catch (Exception)
            {

                return Json(new { success = false }, "text/html");
            }

        }

        [HttpPost]
        public ActionResult UploadFotoAnuncio(string qqfile)
        {
            //var path = @"C:\\";
            var path = @Server.MapPath("/Imagens/Anuncios/");
            var arquivo = string.Empty;
            var arquivoMini = string.Empty;
            var arquivoPequeno = string.Empty;

            var ext = string.Empty;
            try
            {
                var stream = Request.InputStream;
                if (String.IsNullOrEmpty(Request["qqfile"]))
                {
                    // IE
                    HttpPostedFileBase postedFile = Request.Files[0];
                    stream = postedFile.InputStream;
                    ext = System.IO.Path.GetExtension(Request.Files[0].FileName);
                }
                else
                {
                    //Webkit, Mozilla
                    ext = qqfile.Substring(qqfile.LastIndexOf('.'));
                }

                DateTime dtAtual = DateTime.Now;
                
                arquivo = String.Format("{0}{1}{2}", UsuarioLogado_ID, dtAtual.ToString("yyyyMMddHHmmssfff"), ext);
                arquivoPequeno = String.Format("{0}{1}p{2}", UsuarioLogado_ID, dtAtual.ToString("yyyyMMddHHmmssfff"), ext);
                arquivoMini = String.Format("{0}{1}s{2}", UsuarioLogado_ID, dtAtual.ToString("yyyyMMddHHmmssfff"), ext);

                
                var NomeCompletoDoArquivo = path + arquivo;
                var NomeCompletoDoArquivoPequeno = path + arquivoPequeno;
                var NomeCompletoDoArquivoMini = path + arquivoMini;

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                System.IO.File.WriteAllBytes(NomeCompletoDoArquivo, buffer);

                using (System.Drawing.Image Img = System.Drawing.Image.FromFile(NomeCompletoDoArquivo))
                {
                    Size ThumbNailSize = NewImageSize(Img.Height, Img.Width, 90);
                    using (System.Drawing.Image ImgThnail =
                        new Bitmap(Img, ThumbNailSize.Width, ThumbNailSize.Height))
                    {
                        if (ImgThnail.Width == ImgThnail.Height)
                        {
                            ImgThnail.Save(NomeCompletoDoArquivoMini, Img.RawFormat);
                        }
                        else if (ImgThnail.Width > ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Width - ImgThnail.Height;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(tamanhoCorte/2,0),new Size(ImgThnail.Height, ImgThnail.Height)),ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoMini, Img.RawFormat);
                        }
                        else if (ImgThnail.Width < ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Height - ImgThnail.Width;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(0, tamanhoCorte / 2), new Size(ImgThnail.Width, ImgThnail.Width)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoMini, Img.RawFormat);

                        }
                        ImgThnail.Dispose();
                    }
                    Img.Dispose();
                }

                using (System.Drawing.Image Img = System.Drawing.Image.FromFile(NomeCompletoDoArquivo))
                {
                    Size ThumbNailSize = NewImageSize(Img.Height, Img.Width, 320);
                    using (System.Drawing.Image ImgThnail =
                        new Bitmap(Img, ThumbNailSize.Width, ThumbNailSize.Height))
                    {
                        if (ImgThnail.Width == ImgThnail.Height)
                        {
                            ImgThnail.Save(NomeCompletoDoArquivoPequeno, Img.RawFormat);
                        }
                        else if (ImgThnail.Width > ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Width - ImgThnail.Height;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(tamanhoCorte / 2, 0), new Size(ImgThnail.Height, ImgThnail.Height)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoPequeno, Img.RawFormat);
                        }
                        else if (ImgThnail.Width < ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Height - ImgThnail.Width;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(0, tamanhoCorte / 2), new Size(ImgThnail.Width, ImgThnail.Width)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoPequeno, Img.RawFormat);

                        }
                        ImgThnail.Dispose();
                    }
                    Img.Dispose();
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }

            return Json(new { success = true, arquivo = arquivoMini, arquivoOriginal = arquivo }, "text/html");

        }

        [HttpPost]
        public ActionResult UploadFotoUsuario(string qqfile)
        {
            var path = @Server.MapPath("/Imagens/Usuarios/");
            var arquivo = string.Empty;
            var arquivoMini = string.Empty;
            var arquivoPequeno = string.Empty;

            var ext = string.Empty;
            try
            {
                var stream = Request.InputStream;
                if (String.IsNullOrEmpty(Request["qqfile"]))
                {
                    // IE
                    HttpPostedFileBase postedFile = Request.Files[0];
                    stream = postedFile.InputStream;
                    ext = System.IO.Path.GetExtension(Request.Files[0].FileName);
                }
                else
                {
                    //Webkit, Mozilla
                    ext = qqfile.Substring(qqfile.LastIndexOf('.'));
                }

                DateTime dtAtual = DateTime.Now;

                arquivo = String.Format("{0}{1}{2}", UsuarioLogado_ID, dtAtual.ToString("yyyyMMddHHmmssfff"), ext);
                arquivoPequeno = String.Format("{0}{1}p{2}", UsuarioLogado_ID, dtAtual.ToString("yyyyMMddHHmmssfff"), ext);
                arquivoMini = String.Format("{0}{1}s{2}", UsuarioLogado_ID, dtAtual.ToString("yyyyMMddHHmmssfff"), ext);


                var NomeCompletoDoArquivo = path + arquivo;
                var NomeCompletoDoArquivoPequeno = path + arquivoPequeno;
                var NomeCompletoDoArquivoMini = path + arquivoMini;

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                System.IO.File.WriteAllBytes(NomeCompletoDoArquivo, buffer);

                using (System.Drawing.Image Img = System.Drawing.Image.FromFile(NomeCompletoDoArquivo))
                {
                    Size ThumbNailSize = NewImageSize(Img.Height, Img.Width, 90);
                    using (System.Drawing.Image ImgThnail =
                        new Bitmap(Img, ThumbNailSize.Width, ThumbNailSize.Height))
                    {
                        if (ImgThnail.Width == ImgThnail.Height)
                        {
                            ImgThnail.Save(NomeCompletoDoArquivoMini, Img.RawFormat);
                        }
                        else if (ImgThnail.Width > ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Width - ImgThnail.Height;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(tamanhoCorte / 2, 0), new Size(ImgThnail.Height, ImgThnail.Height)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoMini, Img.RawFormat);
                        }
                        else if (ImgThnail.Width < ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Height - ImgThnail.Width;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(0, tamanhoCorte / 2), new Size(ImgThnail.Width, ImgThnail.Width)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoMini, Img.RawFormat);

                        }
                        ImgThnail.Dispose();
                    }
                    Img.Dispose();
                }

                using (System.Drawing.Image Img = System.Drawing.Image.FromFile(NomeCompletoDoArquivo))
                {
                    Size ThumbNailSize = NewImageSize(Img.Height, Img.Width, 320);
                    using (System.Drawing.Image ImgThnail =
                        new Bitmap(Img, ThumbNailSize.Width, ThumbNailSize.Height))
                    {
                        if (ImgThnail.Width == ImgThnail.Height)
                        {
                            ImgThnail.Save(NomeCompletoDoArquivoPequeno, Img.RawFormat);
                        }
                        else if (ImgThnail.Width > ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Width - ImgThnail.Height;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(tamanhoCorte / 2, 0), new Size(ImgThnail.Height, ImgThnail.Height)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoPequeno, Img.RawFormat);
                        }
                        else if (ImgThnail.Width < ImgThnail.Height)
                        {
                            Bitmap ImgAux = new Bitmap(ImgThnail);
                            var tamanhoCorte = ImgThnail.Height - ImgThnail.Width;
                            Bitmap ImgCortada = ImgAux.Clone(new Rectangle(new Point(0, tamanhoCorte / 2), new Size(ImgThnail.Width, ImgThnail.Width)), ImgAux.PixelFormat);
                            ImgCortada.Save(NomeCompletoDoArquivoPequeno, Img.RawFormat);

                        }
                        ImgThnail.Dispose();
                    }
                    Img.Dispose();
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }

            return Json(new { success = true, arquivo = arquivoMini, arquivoOriginal = arquivo }, "text/html");

        }


        public ActionResult Modal(string parameter)
        {
            

            ViewData["SessaoAtual"] = Sessao.ToString().Replace("-", "");


            if (Request.QueryString["p"] != null && Request.QueryString["p"] != String.Empty)
            {
                return PartialView("ucModal" + parameter, Request.QueryString["p"]);
            }
            else
            {
                return PartialView("ucModal" + parameter);
            }
        }
    }
}
