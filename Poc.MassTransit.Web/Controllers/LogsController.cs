using MassTransit;
using Newtonsoft.Json;
using Poc.MassTransit.Message;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Poc.MassTransit.Web.Controllers
{
    public class LogsController : Controller
    {
        private readonly IBus _bus;
        public LogsController(IBus bus)
        {
            _bus = bus;
        }

        // GET: Logs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Logs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var log = new LogTeste();

                log.Id = Guid.NewGuid();
                log.CreatedAt = DateTime.Now;
                log.Action = collection["Action"].ToString();

                var endpoint =  _bus.GetSendEndpoint(new Uri("amqp://localhost/logsPortal")).Result;

                var json = JsonConvert.SerializeObject(log);

                endpoint.Send(log);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
