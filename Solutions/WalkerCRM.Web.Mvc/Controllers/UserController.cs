using System.Web.Mvc;
using SharpArch.NHibernate.Contracts.Repositories;
using WalkerCRM.Domain;

namespace WalkerCRM.Web.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly INHibernateRepository<User> userRepository;

        public UserController(INHibernateRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(userRepository.GetAll());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            return View(userRepository.Get(id));
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.SaveOrUpdate(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View(userRepository.Get(id));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.SaveOrUpdate(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View(userRepository.Get(id));
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = userRepository.Get(id);
            userRepository.Delete(user);

            return RedirectToAction("Index");
        }
    }
}