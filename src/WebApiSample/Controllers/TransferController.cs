namespace WebApiSample.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Crm.Commands;

    public class TransferController : Controller
    {
        private readonly ICommandBuilder commandBuilder;

        public TransferController(ICommandBuilder commandBuilder)
        {
            this.commandBuilder = commandBuilder;
        }

        [System.Web.Http.HttpPost]
        public ActionResult TransferClient(TransferClientToManager command)
        {
            // реалиция роутинга команды сделана через IoC (абстрактная фабрика с контекстом - CommandInstaller)
            // можно сделать через Bus как https://github.com/gregoryyoung/m-r

            commandBuilder.Execute(command);

            return Json(HttpStatusCode.OK, JsonRequestBehavior.AllowGet);
        }
    }
}