using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FileUpload.Controllers
{
    public class CryptoController : Controller
    {
        [HttpGet]
        public ActionResult Data()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Encrypt(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Save(file);
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.Load(path);
                    }
                    catch (XmlException)
                    {
                        doc = null;
                    }
                    if (doc != null)
                    {
                        Encrypt(path, doc, false);
                        ViewBag.Type = "encrypt";
                        ViewBag.Message = Path.GetFileName(path);
                    }
                    else
                    {
                        ViewBag.Type = "error-encrypt";
                        ViewBag.Message = "File is not a valid xml!!";
                    }
                }
                else
                {
                    ViewBag.Type = "error-encrypt";
                    ViewBag.Message = "File does not conatin any data!";
                }
                return View("Data");
            }
            catch(Exception)
            {
                ViewBag.Type = "error";
                ViewBag.Message = "File upload failed!!";
                return View("Data");
            }
        }

        [HttpPost]
        public ActionResult Decrypt(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Save(file);
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.Load(path);
                    }
                    catch (XmlException)
                    {
                        doc = null;
                    }
                    if (doc != null)
                    {
                        Encrypt(path, doc, true);
                        ViewBag.Type = "decrypt";
                        ViewBag.Message = Path.GetFileName(path);
                    }
                    else
                    {
                        ViewBag.Type = "error";
                        ViewBag.Message = "File is not a valid xml!!";
                    }
                }
                else
                {
                    ViewBag.Type = "error";
                    ViewBag.Message = "File does not conatin any data!";
                }
                return View("Data");
            }
            catch (Exception)
            {
                ViewBag.Message = "File upload failed!!";
                return View("Data");
            }
        }

        public ActionResult Download(string path)
        {
            return File(Server.MapPath($"~/UploadedFiles/{path}"), "application/octet-stream", path.Substring(37));
        }

        private string Save(HttpPostedFileBase file)
        {
            string guid = Guid.NewGuid().ToString();
            string fileName = $"{guid}_{Path.GetFileName(file.FileName)}";
            string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
            file.SaveAs(path);
            return path;
        }

        private void Encrypt(string path, XmlDocument doc, bool isDecrypt)
        {
            var connectionNodes = doc.SelectNodes("/configuration/connectionStrings/add");
            foreach (XmlNode node in connectionNodes)
            {
                XmlElement element = node as XmlElement;
                if(element != null)
                {
                    string text = element.Attributes["connectionString"].Value;
                    element.SetAttribute("connectionString", isDecrypt ? Encryption.Decrypt(text) : Encryption.Encrypt(text));
                }
            }

            var appSettingNodes = doc.SelectNodes("/configuration/appSettings/add");
            foreach (XmlNode node in appSettingNodes)
            {
                XmlElement element = node as XmlElement;
                if (element != null)
                {
                    string text = element.Attributes["value"].Value;
                    element.SetAttribute("value", isDecrypt ? Encryption.Decrypt(text) : Encryption.Encrypt(text));
                }
            }

            doc.Save(path);
        }
    }
}