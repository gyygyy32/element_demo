using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudServer.WebApi
{
        public class CrudController : ApiController
        {
                public static List<CrudDto> DtoData = new List<CrudDto>();

                 static CrudController()
                {
                        DtoData.Add(new CrudDto { field1 = "data11", field2 = "data12", field3 = "data13" });
                        DtoData.Add(new CrudDto { field1 = "data21", field2 = "data22", field3 = "data23" });
                        DtoData.Add(new CrudDto { field1 = "data31", field2 = "data32", field3 = "data33" });
                }

                [Route("api/Crud/Query")]
                [HttpGet]
                public IHttpActionResult Query()
                {
                        //var Res = new BomIdMSDal().QueryBomIdBom(Convert.ToString(para.bomId));
                        return Json(DtoData);
                }
                [Route("api/Crud/Init")]
                [HttpPost]
                public IHttpActionResult Init(dynamic para)
                {
                        
                        
                        return Json(DtoData);
                }
                [Route("api/Crud/Delete")]
                [HttpDelete]
                public IHttpActionResult Delete(string id)
                {
                        DtoData.Remove(DtoData.SingleOrDefault(a => a.field1 == id));
                        return Json(DtoData);
                }
                [Route("api/Crud/Add")]
                [HttpPost]
                public IHttpActionResult Add(CrudDto para)
                {
                        DtoData.Add(new CrudDto { field1 = para.field1, field2 = para.field2, field3 = para.field3 });
                        return Json(DtoData);
                }
                [Route("api/Crud/Update")]
                [HttpPut]
                public IHttpActionResult Update(CrudDto para)
                {
                        DtoData.Remove(DtoData.SingleOrDefault(a => a.field1 ==  para.field1));
                        DtoData.Add(new CrudDto { field1 = para.field1, field2 = para.field2, field3 = para.field3 });
                        return Json(DtoData);
                }
                [Route("api/Crud/Detail")]
                [HttpPut]
                public IHttpActionResult GetEdit(string id)
                {
                        var res= DtoData.SingleOrDefault(a => a.field1 ==id);
                        
                        return Json(res);
                }


        }
        public class CrudDto
        {
                public string field1 { get; set; }
                public string field2 { get; set; }
                public string field3 { get; set; }

        }
}