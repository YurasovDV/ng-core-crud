using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgCoreCRUD.Model.Services;

namespace NgCoreCRUD.Controllers
{
    /// <summary>
    /// Common parent to reduce duplication
    /// </summary>
    public class BaseController : Controller
    {
        public BaseController(IGalleryService service)
        {
            _galleryService = service ?? throw new ArgumentNullException(nameof(service));
        }

        protected IGalleryService _galleryService { get; }
    }
}