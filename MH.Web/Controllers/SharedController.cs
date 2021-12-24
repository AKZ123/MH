using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MH.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0];

                var fileName = Path.GetFileNameWithoutExtension(file.FileName) +"-"+DateTime.Now.Year+"-"+ DateTime.Now.Month + "-" + DateTime.Now.Day+"-"+Guid.NewGuid() +  Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image/Uplod/"), fileName);
                file.SaveAs(path);

                result.Data = new { Success = true, ImageURL = string.Format("/Content/image/Uplod/{0}", fileName) };

                //var newImage = new Image() { Name = fileName };

                //if (ImagesService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
                //else
                //{
                //    result.Data = new { success = false, Message = new HttpStatusCodeResult(500) };
                //}
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }

            return result;
        }

    }
}